using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;

public class MsSqlCardRepository : ICardRepository
{
    private readonly string _connectionString;

    public MsSqlCardRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Card> GetAll()
    {
        var cards = new List<Card>();

        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Cards";
            using (var cmd = new SqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cards.Add(new Card
                    {
                        CardId = (int)reader["CardId"],
                        CardNumber = reader["CardNumber"].ToString(),
                        ExpiryDate = (DateTime)reader["ExpiryDate"],
                        CVV = reader["CVV"].ToString(),
                        CardType = reader["CardType"].ToString(),
                        Balance = (decimal)reader["Balance"],
                        AccountId = (int)reader["AccountId"],
                        IsActive = (bool)reader["IsActive"],
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    });
                }
            }
        }

        return cards;
    }

    public Card GetById(int id)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Cards WHERE CardId = @Id";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Card
                        {
                            CardId = (int)reader["CardId"],
                            CardNumber = reader["CardNumber"].ToString(),
                            ExpiryDate = (DateTime)reader["ExpiryDate"],
                            CVV = reader["CVV"].ToString(),
                            CardType = reader["CardType"].ToString(),
                            Balance = (decimal)reader["Balance"],
                            AccountId = (int)reader["AccountId"],
                            IsActive = (bool)reader["IsActive"],
                            CreatedDate = (DateTime)reader["CreatedDate"]
                        };
                    }
                }
            }
        }
        return null;
    }

    public void Insert(Card entity)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = @"INSERT INTO Cards (CardNumber, ExpiryDate, CVV, CardType, Balance, AccountId, IsActive) 
                             VALUES (@CardNumber, @ExpiryDate, @CVV, @CardType, @Balance, @AccountId, @IsActive)";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CardNumber", entity.CardNumber);
                cmd.Parameters.AddWithValue("@ExpiryDate", entity.ExpiryDate);
                cmd.Parameters.AddWithValue("@CVV", entity.CVV);
                cmd.Parameters.AddWithValue("@CardType", entity.CardType);
                cmd.Parameters.AddWithValue("@Balance", entity.Balance);
                cmd.Parameters.AddWithValue("@AccountId", entity.AccountId);
                cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Update(Card entity)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = @"UPDATE Cards SET CardNumber=@CardNumber, ExpiryDate=@ExpiryDate, CVV=@CVV, 
                             CardType=@CardType, Balance=@Balance, AccountId=@AccountId, IsActive=@IsActive 
                             WHERE CardId=@CardId";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CardId", entity.CardId);
                cmd.Parameters.AddWithValue("@CardNumber", entity.CardNumber);
                cmd.Parameters.AddWithValue("@ExpiryDate", entity.ExpiryDate);
                cmd.Parameters.AddWithValue("@CVV", entity.CVV);
                cmd.Parameters.AddWithValue("@CardType", entity.CardType);
                cmd.Parameters.AddWithValue("@Balance", entity.Balance);
                cmd.Parameters.AddWithValue("@AccountId", entity.AccountId);
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
            string query = "DELETE FROM Cards WHERE CardId=@Id";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<Card> GetCardsByAccountId(int accountId)
    {
        var cards = new List<Card>();

        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Cards WHERE AccountId=@AccountId";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AccountId", accountId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cards.Add(new Card
                        {
                            CardId = (int)reader["CardId"],
                            CardNumber = reader["CardNumber"].ToString(),
                            ExpiryDate = (DateTime)reader["ExpiryDate"],
                            CVV = reader["CVV"].ToString(),
                            CardType = reader["CardType"].ToString(),
                            Balance = (decimal)reader["Balance"],
                            AccountId = (int)reader["AccountId"],
                            IsActive = (bool)reader["IsActive"],
                            CreatedDate = (DateTime)reader["CreatedDate"]
                        });
                    }
                }
            }
        }

        return cards;
    }
}


