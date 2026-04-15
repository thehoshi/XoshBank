using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSqlEmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public MsSqlEmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Employees";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeId = (int)reader["EmployeeId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Position = reader["Position"].ToString(),
                            Salary = (decimal)reader["Salary"],
                            HireDate = (DateTime)reader["HireDate"],
                            IsActive = (bool)reader["IsActive"]
                        });
                    }
                }
            }

            return employees;
        }

        public Employee GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Employees WHERE EmployeeId = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Employee
                            {
                                EmployeeId = (int)reader["EmployeeId"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Position = reader["Position"].ToString(),
                                Salary = (decimal)reader["Salary"],
                                HireDate = (DateTime)reader["HireDate"],
                                IsActive = (bool)reader["IsActive"]
                            };
                        }
                    }
                }
            }
            return null;
        }


        public void Insert(Employee entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Employees (FirstName, LastName, Email, Phone, Position, Salary, HireDate, IsActive) 
                                 VALUES (@FirstName, @LastName, @Email, @Phone, @Position, @Salary, @HireDate, @IsActive)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                    cmd.Parameters.AddWithValue("@Position", entity.Position);
                    cmd.Parameters.AddWithValue("@Salary", entity.Salary);
                    cmd.Parameters.AddWithValue("@HireDate", entity.HireDate);
                    cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Employee entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, 
                                 Position=@Position, Salary=@Salary, HireDate=@HireDate, IsActive=@IsActive 
                                 WHERE EmployeeId=@EmployeeId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
                    cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                    cmd.Parameters.AddWithValue("@Position", entity.Position);
                    cmd.Parameters.AddWithValue("@Salary", entity.Salary);
                    cmd.Parameters.AddWithValue("@HireDate", entity.HireDate);
                    cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Employees WHERE EmployeeId=@Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetActiveEmployees()
        {
            var employees = new List<Employee>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Employees WHERE IsActive=1";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeId = (int)reader["EmployeeId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Position = reader["Position"].ToString(),
                            Salary = (decimal)reader["Salary"],
                            HireDate = (DateTime)reader["HireDate"],
                            IsActive = (bool)reader["IsActive"]
                        });
                    }
                }
            }

            return employees;
        }
    }
}