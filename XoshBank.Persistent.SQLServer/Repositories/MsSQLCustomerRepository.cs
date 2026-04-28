using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLCustomerRepository : ICustomerRepository
    {
        private string connectionString;

        public MsSQLCustomerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #region Delete
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Customers WHERE CustomerID = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsCount = command.ExecuteNonQuery();

                    if (rowsCount != 1)
                        throw new Exception("Something went wrong while updating user");
                    else
                        Console.WriteLine("The operation was completed successfully");
                }
            }
        }
        #endregion

        #region GetAll
        public List<Customer> GetAll()
        {
            List<Customer> customer = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Customers;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customers = new Customer();

                        customers.ID = Convert.ToInt32(reader["CustomerID"]);
                        customers.FirstName = Convert.ToString(reader["FirstName"]);
                        customers.LastName = Convert.ToString(reader["LastName"]);
                        customers.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        customers.Email = Convert.ToString(reader["Email"]);
                        customers.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        customers.FINCode = Convert.ToString(reader["FINCode"]);
                        customers.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                        customers.Address = reader["Address"] == DBNull.Value ? null : Convert.ToString(reader["Address"]);
                        customers.DeletedAt = reader["DeletedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DeletedAt"]);
                        customer.Add(customers);
                    }

                   
                }
                return customer;
            }
        }
        #endregion

        #region GetById
        public Customer GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Account WHERE Id = @Id AND DeletedAt IS NULL";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                ID = Convert.ToInt32(reader["CustomersID"]),
                                FirstName = reader["FirstName"] as string,
                                LastName = reader["LastName"] as string,
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                PhoneNumber = reader["PhoneNumber"] as string,
                                Email = reader["Email"] as string,
                                Address = reader["Address"] as string,
                                FINCode = reader["FINCode"] as string,
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
        public void Insert(Customer customers)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Customers(FirstName,LastName,DateOfBirth,PhoneNumber,Email,Address,FINCode,CreatedAt) " +
                "VALUES(@FirstName,@LastName,@DateOfBirth,@PhoneNumber,@Email,@Address,@FINCode,@CreatedAt)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", customers.FirstName);
                    command.Parameters.AddWithValue("@LastName", customers.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", customers.DateOfBirth);
                    command.Parameters.AddWithValue("@PhoneNumber", customers.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", customers.Email);
                    command.Parameters.AddWithValue("@Address", customers.Address ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FINCode", customers.FINCode);
                    command.Parameters.AddWithValue("@CreatedAt", customers.CreatedAt);

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
        public void Update(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, " +
                "DateOfBirth = @DateOfBirth, PhoneNumber = @PhoneNumber, " +
                "Email = @Email, Address = @Address, FINCode = @FINCode " +
                "WHERE CustomerID = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@FINCode", customer.FINCode);
                    command.Parameters.AddWithValue("@Id", customer.ID);
                    int rowsCount = command.ExecuteNonQuery();
                    if (rowsCount != 1)
                        throw new Exception("Something went wrong while updating user");
                    else
                        Console.WriteLine("The operation was completed successfully");
                }
            }
        }
        #endregion
    }
}
