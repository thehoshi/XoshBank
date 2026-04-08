using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using XoshBankCore;
using XoshBankCore.Entities;
using XoshBankCore.Entities.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLLoanRepository : ILoanRepository
    {
        private readonly string _connectionString;

        public MsSQLLoanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region GetAll
        public List<Loan> GetAll()
        {
            var loans = new List<Loan>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Loan", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loans.Add(new Loan
                        {
                            ID = reader["LoanID"] != DBNull.Value ? Convert.ToInt32(reader["LoanID"]) : 0,
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            ApprovedBy = reader.GetInt32(2),
                            BranchID = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            Amount = reader.GetDouble(4),
                            InterestRate = reader.GetDouble(5),
                            TotalAmount = reader.GetDouble(6),
                            MonthlyPayment = reader.GetDouble(7),
                            Status = reader.GetString(8),
                            LoanType = reader.GetString(9),
                            Currency = reader.GetString(10),
                            StartDate = reader.GetDateTime(11),
                            EndDate = reader.GetDateTime(12),
                            ApprovalDate = reader.GetDateTime(13),
                            DurationMonths = reader.GetInt32(14),
                            LatePaymentFee = reader.IsDBNull(15) ? (double?)null : reader.GetDouble(15),
                            PenaltyRate = reader.IsDBNull(16) ? (double?)null : reader.GetDouble(16),
                            Collateral = reader.GetString(17),
                            Notes = reader.GetString(18),
                            CreatedAt = reader.IsDBNull(19) ? (DateTime?)null : reader.GetDateTime(19),
                            UpdatedAt = reader.IsDBNull(20) ? (DateTime?)null : reader.GetDateTime(20)
                        });
                    }
                }
            }

            return loans;
        }
        #endregion

        #region GetByID

        public Loan GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Loan WHERE LoanID = @LoanID", connection);
                command.Parameters.AddWithValue("@LoanID", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Loan
                        {
                            ID = reader.GetInt32(0),
                            CustomerID = reader.GetInt32(1),
                            ApprovedBy = reader.GetInt32(2),
                            BranchID = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            Amount = reader.GetDouble(4),
                            InterestRate = reader.GetDouble(5),
                            TotalAmount = reader.GetDouble(6),
                            MonthlyPayment = reader.GetDouble(7),
                            Status = reader.GetString(8),
                            LoanType = reader.GetString(9),
                            Currency = reader.GetString(10),
                            StartDate = reader.GetDateTime(11),
                            EndDate = reader.GetDateTime(12),
                            ApprovalDate = reader.GetDateTime(13),
                            DurationMonths = reader.GetInt32(14),
                            LatePaymentFee = reader.IsDBNull(15) ? (double?)null : reader.GetDouble(15),
                            PenaltyRate = reader.IsDBNull(16) ? (double?)null : reader.GetDouble(16),
                            Collateral = reader.GetString(17),
                            Notes = reader.GetString(18),
                            CreatedAt = reader.IsDBNull(19) ? (DateTime?)null : reader.GetDateTime(19),
                            UpdatedAt = reader.IsDBNull(20) ? (DateTime?)null : reader.GetDateTime(20)
                        };
                    }
                }
            }
            return null;

        }
        #endregion

        #region Insert
        public void Insert(Loan entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Loan (CustomerID, ApprovedBy, BranchID, Amount, InterestRate, TotalAmount, MonthlyPayment, Status, LoanType, Currency, StartDate, EndDate, ApprovalDate, DurationMonths, LatePaymentFee, PenaltyRate, Collateral, Notes, CreatedAt, UpdatedAt) " +
                    "VALUES (@CustomerID, @ApprovedBy, @BranchID, @Amount, @InterestRate, @TotalAmount, @MonthlyPayment, @Status, @LoanType, @Currency, @StartDate, @EndDate, @ApprovalDate, @DurationMonths, @LatePaymentFee, @PenaltyRate, @Collateral, @Notes, @CreatedAt, @UpdatedAt)",
                    connection);
                command.Parameters.AddWithValue("@CustomerID", entity.CustomerID);
                command.Parameters.AddWithValue("@ApprovedBy", entity.ApprovedBy);
                command.Parameters.AddWithValue("@BranchID", (object)entity.BranchID ?? DBNull.Value);
                command.Parameters.AddWithValue("@Amount", entity.Amount);
                command.Parameters.AddWithValue("@InterestRate", entity.InterestRate);
                command.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
                command.Parameters.AddWithValue("@MonthlyPayment", entity.MonthlyPayment);
                command.Parameters.AddWithValue("@Status", entity.Status);
                command.Parameters.AddWithValue("@LoanType", entity.LoanType);
                command.Parameters.AddWithValue("@Currency", entity.Currency);
                command.Parameters.AddWithValue("@StartDate", entity.StartDate);
                command.Parameters.AddWithValue("@EndDate", entity.EndDate);
                command.Parameters.AddWithValue("@ApprovalDate", entity.ApprovalDate);
                command.Parameters.AddWithValue("@DurationMonths", entity.DurationMonths);
                command.Parameters.AddWithValue("@LatePaymentFee", (object)entity.LatePaymentFee ?? DBNull.Value);
                command.Parameters.AddWithValue("@PenaltyRate", (object)entity.PenaltyRate ?? DBNull.Value);
                command.Parameters.AddWithValue("@Collateral", entity.Collateral);
                command.Parameters.AddWithValue("@Notes", entity.Notes);
                command.Parameters.AddWithValue("@CreatedAt", (object)entity.CreatedAt ?? DBNull.Value);
                command.Parameters.AddWithValue("@UpdatedAt", (object)entity.UpdatedAt ?? DBNull.Value);

                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Update
        public void Update(Loan entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Loan SET CustomerID = @CustomerID, ApprovedBy = @ApprovedBy, BranchID = @BranchID, Amount = @Amount, InterestRate = @InterestRate, TotalAmount = @TotalAmount, MonthlyPayment = @MonthlyPayment, Status = @Status, LoanType = @LoanType, Currency = @Currency, StartDate = @StartDate, EndDate = @EndDate, ApprovalDate = @ApprovalDate, DurationMonths = @DurationMonths, LatePaymentFee = @LatePaymentFee, PenaltyRate = @PenaltyRate, Collateral = @Collateral, Notes = @Notes, CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt WHERE LoanID = @LoanID",
                    connection);
                command.Parameters.AddWithValue("@LoanID", entity.ID);
                command.Parameters.AddWithValue("@CustomerID", entity.CustomerID);
                command.Parameters.AddWithValue("@ApprovedBy", entity.ApprovedBy);
                command.Parameters.AddWithValue("@BranchID", (object)entity.BranchID ?? DBNull.Value);
                command.Parameters.AddWithValue("@Amount", entity.Amount);
                command.Parameters.AddWithValue("@InterestRate", entity.InterestRate);
                command.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
                command.Parameters.AddWithValue("@MonthlyPayment", entity.MonthlyPayment);
                command.Parameters.AddWithValue("@Status", entity.Status);
                command.Parameters.AddWithValue("@LoanType", entity.LoanType);
                command.Parameters.AddWithValue("@Currency", entity.Currency);
                command.Parameters.AddWithValue("@StartDate", entity.StartDate);
                command.Parameters.AddWithValue("@EndDate", entity.EndDate);
                command.Parameters.AddWithValue("@ApprovalDate", entity.ApprovalDate);
                command.Parameters.AddWithValue("@DurationMonths", entity.DurationMonths);
                command.Parameters.AddWithValue("@LatePaymentFee", (object)entity.LatePaymentFee ?? DBNull.Value);
                command.Parameters.AddWithValue("@PenaltyRate", (object)entity.PenaltyRate ?? DBNull.Value);
                command.Parameters.AddWithValue("@Collateral", entity.Collateral);
                command.Parameters.AddWithValue("@Notes", entity.Notes);
                command.Parameters.AddWithValue("@CreatedAt", (object)entity.CreatedAt ?? DBNull.Value);
                command.Parameters.AddWithValue("@UpdatedAt", (object)entity.UpdatedAt ?? DBNull.Value);
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
                var command = new SqlCommand("DELETE FROM Loan WHERE LoanID = @LoanID", connection);
                command.Parameters.AddWithValue("@LoanID", id);
                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}

