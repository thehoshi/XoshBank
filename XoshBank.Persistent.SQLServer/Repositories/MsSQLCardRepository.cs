using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLCardRepository : ICardRepository
    {
        private readonly string _connectionString;

        public MsSQLCardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region GetAll
        public List<Card> GetAll()
        {
            var cards = new List<Card>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Cards WHERE DeletedAt IS NULL", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var card = new Card
                        {
                            CardId = reader["CardID"] != DBNull.Value ? Convert.ToInt32(reader["CardID"]) : 0,
                            CardNumber = reader["CardNumber"] as string,
                            ExpiryDate = reader["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(reader["ExpiryDate"]) : DateTime.MinValue,
                            CVV = reader["CVV"] as string,
                            CardType = reader["CardType"] as string,
                            Balance = reader["Balance"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["Balance"]) : null,
                            AccountId = reader["AccountID"] != DBNull.Value ? Convert.ToInt32(reader["AccountID"]) : 0,
                            IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]),
                            CreatedDate = reader["CreatedDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["CreatedDate"]) : null,
                            DeletedAt = reader["DeletedAt"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["DeletedAt"]) : null
                        };

                        cards.Add(card);
                    }
                }
            }

            return cards;
        }
        #endregion

        #region GetById
        public Card GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Cards WHERE CardID = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Card
                            {
                                CardId = reader["CardID"] != DBNull.Value ? Convert.ToInt32(reader["CardID"]) : 0,
                                CardNumber = reader["CardNumber"] as string,
                                ExpiryDate = reader["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(reader["ExpiryDate"]) : DateTime.MinValue,
                                CVV = reader["CVV"] as string,
                                CardType = reader["CardType"] as string,
                                Balance = reader["Balance"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["Balance"]) : null,
                                AccountId = reader["AccountID"] != DBNull.Value ? Convert.ToInt32(reader["AccountID"]) : 0,
                                IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]),
                                CreatedDate = reader["CreatedDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["CreatedDate"]) : null,
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
        public void Insert(Card entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Cards (CardID, CardNumber, ExpiryDate, CVV, CardType, Balance, AccountID, IsActive, CreatedDate) " +
                    "VALUES (@CardID, @CardNumber, @ExpiryDate, @CVV, @CardType, @Balance, @AccountID, @IsActive, @CreatedDate)",
                    connection);

                command.Parameters.AddWithValue("@CardID", entity.CardId);
                command.Parameters.AddWithValue("@CardNumber", (object)entity.CardNumber ?? DBNull.Value);
                command.Parameters.AddWithValue("@ExpiryDate", (object)entity.ExpiryDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@CVV", (object)entity.CVV ?? DBNull.Value);
                command.Parameters.AddWithValue("@CardType", (object)entity.CardType ?? DBNull.Value);
                command.Parameters.AddWithValue("@Balance", (object)entity.Balance ?? DBNull.Value);
                command.Parameters.AddWithValue("@AccountID", entity.AccountId);
                command.Parameters.AddWithValue("@IsActive", entity.IsActive);
                command.Parameters.AddWithValue("@CreatedDate", (object)entity.CreatedDate ?? DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Update
        public void Update(Card entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Cards SET CardNumber = @CardNumber, ExpiryDate = @ExpiryDate, CVV = @CVV, CardType = @CardType, " +
                    "Balance = @Balance, AccountID = @AccountID, IsActive = @IsActive, CreatedDate = @CreatedDate " +
                    "WHERE CardID = @CardID",
                    connection);

                command.Parameters.AddWithValue("@CardID", entity.CardId);
                command.Parameters.AddWithValue("@CardNumber", (object)entity.CardNumber ?? DBNull.Value);
                command.Parameters.AddWithValue("@ExpiryDate", (object)entity.ExpiryDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@CVV", (object)entity.CVV ?? DBNull.Value);
                command.Parameters.AddWithValue("@CardType", (object)entity.CardType ?? DBNull.Value);
                command.Parameters.AddWithValue("@Balance", (object)entity.Balance ?? DBNull.Value);
                command.Parameters.AddWithValue("@AccountID", entity.AccountId);
                command.Parameters.AddWithValue("@IsActive", entity.IsActive);
                command.Parameters.AddWithValue("@CreatedDate", (object)entity.CreatedDate ?? DBNull.Value);

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
                    "UPDATE Cards SET DeletedAt = @DeletedAt WHERE CardID = @Id",
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
                var command = new SqlCommand("SELECT ISNULL(MAX(CardID), 0) + 1 FROM Cards", connection);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        #endregion
    }
}
