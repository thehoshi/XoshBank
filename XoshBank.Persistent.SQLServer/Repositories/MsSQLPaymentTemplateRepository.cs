using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLPaymentTemplateRepository : IPaymentTemplateRepository 
    { 
        private readonly string _connectionString;

        public MsSQLPaymentTemplateRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public void Add(PaymentTemplate template)
        {
            if (template == null) return;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO PaymentTemplates (TemplateName, ServiceName, CustomerCode, Amount, IsActive, CreatedDate, CardId) " +
                               "VALUES (@TemplateName, @ServiceName, @CustomerCode, @Amount, @IsActive, @CreatedDate, @CardId)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TemplateName", template.TemplateName);
                    command.Parameters.AddWithValue("@ServiceName", template.ServiceName);
                    command.Parameters.AddWithValue("@CustomerCode", template.CustomerCode);
                    command.Parameters.AddWithValue("@Amount", template.Amount);
                    command.Parameters.AddWithValue("@IsActive", template.IsActive);
                    command.Parameters.AddWithValue("@CreatedDate", template.CreatedDate);
                    command.Parameters.AddWithValue("@CardId", template.CardId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<PaymentTemplate> GetAll()
        {
            var List = new List<PaymentTemplate>();
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(var command = new SqlCommand("SELECT *  FROM PaymentTemplateS", connection))
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pt = new PaymentTemplate
                        {
                            ID = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                            TemplateName = reader["TemplateName"] as string,
                            ServiceName = reader["ServiceName"] as string,
                            CustomerCode = reader["CustomerCode"] as string,
                            Amount = reader["Amount"] != DBNull.Value ? Convert.ToDecimal(reader["Amount"]) : 0,
                            IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]),
                            CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.Now,
                            CardId = reader["CardId"] != DBNull.Value ? Convert.ToInt32(reader["CardId"]) : 0
                        };
                        List.Add(pt);
                    }
                }  
            }
            return List;
        }

        public PaymentTemplate GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(var command = new SqlCommand("SELECT * FROM PaymentTemplate WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using(var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return new PaymentTemplate
                            {
                                ID = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                                TemplateName = reader["TemplateName"] as string,
                                ServiceName = reader["ServiceName"] as string,
                                CustomerCode = reader["CustomerCode"] as string,
                                Amount = reader["Amount"] != DBNull.Value ? Convert.ToDecimal(reader["Amount"]) : 0,
                                IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]),
                                CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.Now,
                                CardId = reader["CardId"] != DBNull.Value ? Convert.ToInt32(reader["CardId"]) : 0
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Insert (PaymentTemplate pt)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(var command = new SqlCommand(
                    "INSERT INTO PaymentTemplates (Templatename, ServiceName, CustomerCode, Amount, IsActive, CreatedDate, CardId) VALUES (@TemplateName, ServiceName, @CustomerCode, @Amount, @IsActive, @CreatedDate, @CardId)", connection))
                {
                    command.Parameters.AddWithValue("TemplateName", pt.TemplateName);
                    command.Parameters.AddWithValue("ServiceName", pt.ServiceName);
                    command.Parameters.AddWithValue("CustomerCode", pt.CustomerCode);
                    command.Parameters.AddWithValue("Amount", pt.Amount);
                    command.Parameters.AddWithValue("IsActive", pt.IsActive);
                    command.Parameters.AddWithValue("CreatedDate", pt.CreatedDate);
                    command.Parameters.AddWithValue("CardId", pt.CardId);
                }
            }
        }

        public void Update (PaymentTemplate pt)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(var command = new SqlCommand(
                    "UPDATE PaymentTemplates  SET Templatename =@TemplateName, ServiceName = @ServiceName, CustomerCode = @CustomerCode, Amount = @Amount, IsActive = @IsActive, CreatedDate = @CreatedDate, CardId = @CardId WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("Id", pt.ID);
                    command.Parameters.AddWithValue("TemplateName", pt.TemplateName);
                    command.Parameters.AddWithValue("ServiceName", pt.ServiceName);
                    command.Parameters.AddWithValue("CustomerCode", pt.CustomerCode);
                    command.Parameters.AddWithValue("Amount", pt.Amount);
                    command.Parameters.AddWithValue("IsActive", pt.IsActive);
                    command.Parameters.AddWithValue("CreatedDate", pt.CreatedDate);
                    command.Parameters.AddWithValue("CardId", pt.CardId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(var command = new SqlCommand ("DELETE FROM PaymentTemplates WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue ("Id", id);
                    command.ExecuteNonQuery ();
                }
            }
        }
    }
}
