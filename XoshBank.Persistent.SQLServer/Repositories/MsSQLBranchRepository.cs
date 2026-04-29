using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLBranchRepository : IBranchRepository
    {
        private readonly string _connectionString;

        public MsSQLBranchRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region GetALl
        public List<Branch> GetAll()
        {
            var branches = new List<Branch>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Branches WHERE DeletedAt IS NULL", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var branch = new Branch
                        {
                            ID = reader["BranchID"] != DBNull.Value ? Convert.ToInt32(reader["BranchID"]) : 0,
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
        #endregion

        #region GetByID
        public Branch GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT * FROM Branches WHERE BranchID = @Id",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Branch
                            {
                                ID = reader["BranchID"] != DBNull.Value ? Convert.ToInt32(reader["BranchID"]) : 0,
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
        #endregion 

        #region Insert
        public void Insert(Branch entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Branches (BranchID, BranchName, City, Address, ManagerName, PhoneNumber, EmployeeCount, OpeningDate, Revenue, Expenses) " +
                    "VALUES (@BranchID, @BranchName, @City, @Address, @ManagerName, @PhoneNumber, @EmployeeCount, @OpeningDate, @Revenue, @Expenses)",
                    connection);

                command.Parameters.AddWithValue("@BranchID", entity.ID);
                command.Parameters.AddWithValue("@BranchName", (object)entity.BranchName ?? DBNull.Value);
                command.Parameters.AddWithValue("@City", (object)entity.City ?? DBNull.Value);
                command.Parameters.AddWithValue("@Address", (object)entity.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@ManagerName", (object)entity.ManagerName ?? DBNull.Value);
                command.Parameters.AddWithValue("@PhoneNumber", (object)entity.PhoneNumber ?? DBNull.Value);
                command.Parameters.AddWithValue("@EmployeeCount", (object)entity.EmployeeCount ?? DBNull.Value);
                command.Parameters.AddWithValue("@OpeningDate", (object)entity.OpeningDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@Revenue", (object)entity.Revenue ?? DBNull.Value);
                command.Parameters.AddWithValue("@Expenses", (object)entity.Expenses ?? DBNull.Value);

                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Update
        public void Update(Branch entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Branches SET BranchName = @BranchName, City = @City, Address = @Address, ManagerName = @ManagerName, PhoneNumber = @PhoneNumber, EmployeeCount = @EmployeeCount, OpeningDate = @OpeningDate, Revenue = @Revenue, Expenses = @Expenses ",
                    connection);
                command.Parameters.AddWithValue("@BranchName", entity.BranchName);
                command.Parameters.AddWithValue("@City", entity.City);
                command.Parameters.AddWithValue("@Address", entity.Address);
                command.Parameters.AddWithValue("@ManagerName", entity.ManagerName);
                command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber); 
                command.Parameters.AddWithValue("@EmployeeCount", (object)entity.EmployeeCount ?? DBNull.Value);
                command.Parameters.AddWithValue("@OpeningDate", (object)entity.OpeningDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@Revenue", (object)entity.Revenue ?? DBNull.Value);
                command.Parameters.AddWithValue("@Expenses", (object)entity.Expenses ?? DBNull.Value);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region delete
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Branches SET DeletedAt = @DeletedAt WHERE BranchID = @Id",
                    connection);

                command.Parameters.AddWithValue("@DeletedAt", DateTime.Now);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region GetNextID
        public int GetNextId()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT ISNULL(MAX(BranchID), 0) + 1 FROM Branches",
                    connection);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        #endregion
    }
}
