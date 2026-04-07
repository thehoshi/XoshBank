using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using XoshBank.App.Entities;
using XoshBankCore.Entites.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLATMLocationRepository : IATMLocationRepository
    {
        private readonly string _connectionString;

        public MsSQLATMLocationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region GetAll
        public List<ATMLocation> GetAll()
        {
            var atmLocations = new List<ATMLocation>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM ATMLocations", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var atm = new ATMLocation
                        {
                            ID = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                            Name = reader["Name"] as string,
                            City = reader["City"] as string,
                            Address = reader["Address"] as string,
                            Latitude = reader["Latitude"] != DBNull.Value ? Convert.ToDecimal(reader["Latitude"]) : 0,
                            Longitude = reader["Longitude"] != DBNull.Value ? Convert.ToDecimal(reader["Longitude"]) : 0,
                            IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"])
                        };
                        atmLocations.Add(atm);
                    }
                }
            }
            return atmLocations;
        }
        #endregion

        #region GetById
        public ATMLocation GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM ATMLocations WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ATMLocation
                            {
                                ID = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                                Name = reader["Name"] as string,
                                City = reader["City"] as string,
                                Address = reader["Address"] as string,
                                Latitude = reader["Latitude"] != DBNull.Value ? Convert.ToDecimal(reader["Latitude"]) : 0,
                                Longitude = reader["Longitude"] != DBNull.Value ? Convert.ToDecimal(reader["Longitude"]) : 0,
                                IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            return null;
        }
        #endregion

        #region Insert
        public void Insert(ATMLocation atm)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "INSERT INTO ATMLocations (Name, City, Address, Latitude, Longitude, IsActive) VALUES (@Name, @City, @Address, @Latitude, @Longitude, @IsActive)", connection))
                {
                    command.Parameters.AddWithValue("@Name", atm.Name);
                    command.Parameters.AddWithValue("@City", atm.City);
                    command.Parameters.AddWithValue("@Address", atm.Address);
                    command.Parameters.AddWithValue("@Latitude", atm.Latitude);
                    command.Parameters.AddWithValue("@Longitude", atm.Longitude);
                    command.Parameters.AddWithValue("@IsActive", atm.IsActive);
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(ATMLocation atm)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "UPDATE ATMLocations SET Name=@Name, City=@City, Address=@Address, Latitude=@Latitude, Longitude=@Longitude, IsActive=@IsActive WHERE Id=@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", atm.ID);
                    command.Parameters.AddWithValue("@Name", atm.Name);
                    command.Parameters.AddWithValue("@City", atm.City);
                    command.Parameters.AddWithValue("@Address", atm.Address);
                    command.Parameters.AddWithValue("@Latitude", atm.Latitude);
                    command.Parameters.AddWithValue("@Longitude", atm.Longitude);
                    command.Parameters.AddWithValue("@IsActive", atm.IsActive);
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM ATMLocations WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}