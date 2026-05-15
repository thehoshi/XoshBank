using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLAccountRepository : IAccountRepository
    {
        private readonly string _connectionString;

        public MsSQLAccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #region Delete
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Accounts SET DeletedAt = @DeletedAt WHERE Id = @Id AND DeletedAt IS NULL";

                var command = new SqlCommand(query,connection);

                command.Parameters.AddWithValue("@DeletedAt", DateTime.Now);
                command.Parameters.AddWithValue("@Id", id);

                int rowsCount = command.ExecuteNonQuery();

                if (rowsCount != 1)
                    throw new Exception("Something went wrong while updating user");
                else
                    Console.WriteLine("The operation was completed successfully");
            }
        }
        #endregion

        #region GetAll
        public List<Account> GetAll()
        {
            var accounts = new List<Account>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Accounts WHERE DeletedAt IS NULL";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var account = new Account
                        {
                            ID = Convert.ToInt32(reader["AccountID"]),
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            AccountNumber = reader["AccountNumber"] as string,
                            Balance = Convert.ToDecimal(reader["Balance"]),
                            AccountType = reader["AccountType"] as string,
                            Currency = reader["Currency"] as string,
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            DeletedAt = reader["DeletedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DeletedAt"]) 
                        };
                        
                        accounts.Add(account);
                    }
              
                }
            }
            return accounts;
        }
        #endregion

        #region GetById
        public Account GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();
                string query = "SELECT * FROM Accounts WHERE AccountID = @Id AND DeletedAt IS NULL";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Account
                            {
                                ID = Convert.ToInt32(reader["AccountsID"]),
                                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                AccountNumber = reader["AccountNumber"] as string,
                                Balance = Convert.ToDecimal(reader["Balance"]),
                                AccountType = reader["AccountType"] as string,
                                Currency = reader["Currency"] as string,
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                DeletedAt = Convert.ToDateTime(reader["DeletedAt"]),
                            };
                        }

                        int rowsCount = command.ExecuteNonQuery();

                        if (rowsCount != 1)
                            throw new Exception("Something went wrong while updating user");
                        else
                            Console.WriteLine("The operation was completed successfully");
                    }
                }
            }
            return null;
        }
        #endregion

        #region Insert
        public void Insert(Account account)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Accounts (CustomerID,AccountNumber,Balance,AccountType,Currency,CreatedAt,DeletedAt) " +
                    "VALUES(@CustomerID,@AccountNumber,@Balance,@AccountType,@Currency,@CreatedAt,@DeletedAt)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", account.CustomerID);
                    command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
                    command.Parameters.AddWithValue("@Balance", account.Balance);
                    command.Parameters.AddWithValue("@AccountType", account.AccountType ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Currency", account.Currency);
                    command.Parameters.AddWithValue("@CreatedAt", account.CreatedAt);
                    command.Parameters.AddWithValue("@DeletedAt",account.DeletedAt ?? (object)DBNull.Value);

                    int rowsCount = command.ExecuteNonQuery();
                    if (rowsCount != 1)
                        throw new Exception("Something went wrong while updating user");
                    else
                        Console.WriteLine("The operation was completed successfully");
                }
            }
        }
        #endregion

        #region Update
        public void Update(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Accounts SET CustomerID = @CustomerID, AccountNumber = @AccountNumber, Balance = @Balance, AccountType = @AccountType, Currency = @Currency " +
                    "CreatedAt = @CreatedAt, DeletedAt = @DeletedAt WHERE AccountID = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", account.CustomerID);
                    command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
                    command.Parameters.AddWithValue("@Balance", account.Balance);
                    command.Parameters.AddWithValue("@AccountType", account.AccountType);
                    command.Parameters.AddWithValue("@Currency", account.Currency);
                    command.Parameters.AddWithValue("@CreatedAt", account.CreatedAt);
                    command.Parameters.AddWithValue("@DeletedAt", account.DeletedAt);

                    int rowsCount = command.ExecuteNonQuery();

                    if (rowsCount != 1)
                        throw new Exception("Something went wrong while updating user");
                    else
                        Console.WriteLine("The operation was completed successfully");
                }
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
                    "SELECT ISNULL(MAX(AccountID), 0) + 1 FROM Accounts",
                    connection);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        #endregion
    }
}

