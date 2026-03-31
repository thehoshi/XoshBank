using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using XoshBankCore;
using XoshBankCore.Entities.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLAccountsRepository : AccountsRepository
    {
        private readonly string _connectionString;

        public MsSQLAccountsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Accounts SET DeletedAt = @DeletedAt WHERE Id = @Id AND DeletedAt IS NULL",
                    connection);

                command.Parameters.AddWithValue("@DeletedAt", DateTime.Now);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Accounts> GetAll()
        {
            var accounts = new List<Accounts>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Accounts", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var account = new Accounts
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

                        accounts.Add(account);
                    }
                }
            }
            return accounts;
        }

        public Accounts GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Accounts entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Accounts entity)
        {
            throw new NotImplementedException();
        }
    }
}

