using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLEmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public MsSQLEmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region GetAll
        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Employees WHERE DeletedAt IS NULL", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new Employee
                        {
                            EmployeeId = reader["EmployeeId"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeId"]) : 0,
                            FirstName = reader["FirstName"] as string,
                            LastName = reader["LastName"] as string,
                            Email = reader["Email"] as string,
                            Phone = reader["Phone"] as string,
                            Position = reader["Position"] as string,
                            Salary = reader["Salary"] != DBNull.Value ? Convert.ToDecimal(reader["Salary"]) : 0,
                            HireDate = reader["HireDate"] != DBNull.Value ? Convert.ToDateTime(reader["HireDate"]) : DateTime.MinValue,
                            IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]),
                            DeletedAt = reader["DeletedAt"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["DeletedAt"]) : null
                        };

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }
        #endregion

        #region GetById
        public Employee GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Employees WHERE EmployeeId = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Employee
                            {
                                EmployeeId = reader["EmployeeId"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeId"]) : 0,
                                FirstName = reader["FirstName"] as string,
                                LastName = reader["LastName"] as string,
                                Email = reader["Email"] as string,
                                Phone = reader["Phone"] as string,
                                Position = reader["Position"] as string,
                                Salary = reader["Salary"] != DBNull.Value ? Convert.ToDecimal(reader["Salary"]) : 0,
                                HireDate = reader["HireDate"] != DBNull.Value ? Convert.ToDateTime(reader["HireDate"]) : DateTime.MinValue,
                                IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]),
                                DeletedAt = reader["DeletedAt"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["DeletedAt"]) : null
                            };
                        }
                    }
                }
            }

            return null;
        }
        #endregion

        #region Insert
        public void Insert(Employee entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Employees (EmployeeId, FirstName, LastName, Email, Phone, Position, Salary, HireDate, IsActive, CreatedDate) " +
                    "VALUES (@EmployeeId, @FirstName, @LastName, @Email, @Phone, @Position, @Salary, @HireDate, @IsActive, @CreatedDate)",
                    connection);

                command.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
                command.Parameters.AddWithValue("@FirstName", (object)entity.FirstName ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastName", (object)entity.LastName ?? DBNull.Value);
                command.Parameters.AddWithValue("@Email", (object)entity.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)entity.Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Position", (object)entity.Position ?? DBNull.Value);
                command.Parameters.AddWithValue("@Salary", entity.Salary);
                command.Parameters.AddWithValue("@HireDate", entity.HireDate);
                command.Parameters.AddWithValue("@IsActive", entity.IsActive);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Update
        public void Update(Employee entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, " +
                    "Position = @Position, Salary = @Salary, HireDate = @HireDate, IsActive = @IsActive, CreatedDate = @CreatedDate " +
                    "WHERE EmployeeId = @EmployeeId",
                    connection);

                command.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
                command.Parameters.AddWithValue("@FirstName", (object)entity.FirstName ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastName", (object)entity.LastName ?? DBNull.Value);
                command.Parameters.AddWithValue("@Email", (object)entity.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)entity.Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Position", (object)entity.Position ?? DBNull.Value);
                command.Parameters.AddWithValue("@Salary", entity.Salary);
                command.Parameters.AddWithValue("@HireDate", entity.HireDate);
                command.Parameters.AddWithValue("@IsActive", entity.IsActive);

                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Employees SET DeletedAt = @DeletedAt WHERE EmployeeId = @Id",
                    connection);

                command.Parameters.AddWithValue("@DeletedAt", DateTime.Now);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region GetNextId
        public int GetNextId()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT ISNULL(MAX(EmployeeId), 0) + 1 FROM Employees", connection);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        #endregion
    }
}
