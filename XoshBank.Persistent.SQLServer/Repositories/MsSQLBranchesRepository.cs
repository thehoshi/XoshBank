using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using XoshBankCore;
using XoshBankCore.Entities;
using XoshBankCore.Entities.Repositories;

namespace XoshBank.Persistent.SQLServer
{    public class MsSQLBranchesRepository : IBranchesRepository
    {
        private readonly string _connectionString;

        public MsSQLBranchesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Branches> GetAll()
        {
            var branches = new List<Branches>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Branches", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var branch = new Branches
                        {
                            BranchID = reader["BranchID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["BranchID"]) : null,
                            BranchName = reader["BranchName"] as string,
                            City = reader["City"] as string,
                            Address = reader["Address"] as string,
                            ManagerName = reader["ManagerName"] as string,
                            PhoneNumber = reader["PhoneNumber"] as string,
                            EmployeeCount = reader["EmployeeCount"] != DBNull.Value ? (int?)Convert.ToInt32(reader["EmployeeCount"]) : null,
                            OpeningDate = reader["OpeningDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["OpeningDate"]) : null,
                            Revenue = reader["Revenue"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Revenue"]) : null,
                            Expenses = reader["Expenses"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Expenses"]) : null
                        };

                        branches.Add(branch);
                    }
                }
            }

            return branches;
        }

        public Branches GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT * FROM Branches WHERE Id = @Id",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Branches
                            {
                                BranchID = reader["BranchID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["BranchID"]) : null,
                                BranchName = reader["BranchName"] as string,
                                City = reader["City"] as string,
                                Address = reader["Address"] as string,
                                ManagerName = reader["ManagerName"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                EmployeeCount = reader["EmployeeCount"] != DBNull.Value ? (int?)Convert.ToInt32(reader["EmployeeCount"]) : null,
                                OpeningDate = reader["OpeningDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["OpeningDate"]) : null,
                                Revenue = reader["Revenue"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Revenue"]) : null,
                                Expenses = reader["Expenses"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Expenses"]) : null
                            };
                        }
                    }
                }
            }

            return null;
        }
        public void Insert(Branches entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Branches (BranchName, City, Address, ManagerName, PhoneNumber, EmployeeCount, OpeningDate, Revenue, Expenses) " +
                    "VALUES (@BranchName, @City, @Address, @ManagerName, @PhoneNumber, @EmployeeCount, @OpeningDate, @Revenue, @Expenses)",
                    connection);
                command.Parameters.AddWithValue("@BranchName", entity.BranchName);
                command.Parameters.AddWithValue("@City", entity.City);
                command.Parameters.AddWithValue("@Address", entity.Address);
                command.Parameters.AddWithValue("@ManagerName", entity.ManagerName);
                command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                command.Parameters.AddWithValue("@EmployeeCount", entity.EmployeeCount);
                command.Parameters.AddWithValue("@OpeningDate", entity.OpeningDate);
                command.Parameters.AddWithValue("@Revenue", entity.Revenue);
                command.Parameters.AddWithValue("@Expenses", entity.Expenses);
                command.ExecuteNonQuery();
            }
        }
        public void Update(Branches entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Branches SET BranchName = @BranchName, City = @City, Address = @Address, ManagerName = @ManagerName, PhoneNumber = @PhoneNumber, EmployeeCount = @EmployeeCount, OpeningDate = @OpeningDate, Revenue = @Revenue, Expenses = @Expenses " +
                    "WHERE BranchID = @BranchID",
                    connection);
                command.Parameters.AddWithValue("@BranchID", entity.BranchID);
                command.Parameters.AddWithValue("@BranchName", entity.BranchName);
                command.Parameters.AddWithValue("@City", entity.City);
                command.Parameters.AddWithValue("@Address", entity.Address);
                command.Parameters.AddWithValue("@ManagerName", entity.ManagerName);
                command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                command.Parameters.AddWithValue("@EmployeeCount", entity.EmployeeCount);
                command.Parameters.AddWithValue("@OpeningDate", entity.OpeningDate);
                command.Parameters.AddWithValue("@Revenue", entity.Revenue);
                command.Parameters.AddWithValue("@Expenses", entity.Expenses);
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM Branches WHERE BranchID = @Id",
                    connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
