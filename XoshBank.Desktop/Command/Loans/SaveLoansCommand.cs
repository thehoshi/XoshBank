using System;
using System.Windows;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Loans
{
    public class SaveLoansCommand : ICommand
    {
        private readonly LoansControlViewModel _viewModel;

        public SaveLoansCommand(LoansControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (_viewModel.CurrentLoan == null)
                _viewModel.CurrentLoan = new LoanFormModel();

            var result = MessageBox.Show("Are you sure you want to save?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;

            var source = _viewModel.CurrentLoan;

            var loan = new Loan
            {
                CustomerID = source.CustomerID,
                ApprovedBy = source.ApprovedBy,
                BranchID = source.BranchID,
                Amount = source.Amount,
                InterestRate = source.InterestRate,
                TotalAmount = source.TotalAmount,
                MonthlyPayment = source.MonthlyPayment,
                Status = source.Status,
                LoanType = source.LoanType,
                Currency = source.Currency,
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                ApprovalDate = source.ApprovalDate,
                DurationMonths = source.DurationMonths,
                LatePaymentFee = source.LatePaymentFee,
                PenaltyRate = source.PenaltyRate,
                Collateral = source.Collateral,
                Notes = source.Notes,
                UpdatedAt = DateTime.Now
            };

            bool isEdit = _viewModel.SelectedLoan != null && _viewModel.SelectedLoan.No > 0;

            if (isEdit)
            {
                loan.ID = _viewModel.SelectedLoan.No;
                _viewModel.DB.Loans.Update(loan);

                int index = _viewModel.Loans.IndexOf(_viewModel.SelectedLoan);
                var updated = new LoanUIModel
                {
                    No = loan.ID,
                    CustomerID = loan.CustomerID,
                    ApprovedBy = loan.ApprovedBy,
                    BranchID = loan.BranchID,
                    Amount = loan.Amount,
                    InterestRate = loan.InterestRate,
                    TotalAmount = loan.TotalAmount,
                    MonthlyPayment = loan.MonthlyPayment,
                    Status = loan.Status,
                    LoanType = loan.LoanType,
                    Currency = loan.Currency,
                    StartDate = loan.StartDate,
                    EndDate = loan.EndDate,
                    ApprovalDate = loan.ApprovalDate,
                    DurationMonths = loan.DurationMonths,
                    LatePaymentFee = loan.LatePaymentFee,
                    PenaltyRate = loan.PenaltyRate,
                    Collateral = loan.Collateral,
                    Notes = loan.Notes
                };

                if (index >= 0)
                {
                    _viewModel.AllLoans[index] = updated;
                    _viewModel.Loans[index] = updated;
                }

                MessageBox.Show("Loan updated successfully!", "Success", MessageBoxButton.OK);
            }
            else
            {
                loan.CreatedAt = DateTime.Now;
                _viewModel.DB.Loans.Insert(loan);

                var newModel = new LoanUIModel
                {
                    No = loan.ID,
                    CustomerID = loan.CustomerID,
                    ApprovedBy = loan.ApprovedBy,
                    BranchID = loan.BranchID,
                    Amount = loan.Amount,
                    InterestRate = loan.InterestRate,
                    TotalAmount = loan.TotalAmount,
                    MonthlyPayment = loan.MonthlyPayment,
                    Status = loan.Status,
                    LoanType = loan.LoanType,
                    Currency = loan.Currency,
                    StartDate = loan.StartDate,
                    EndDate = loan.EndDate,
                    ApprovalDate = loan.ApprovalDate,
                    DurationMonths = loan.DurationMonths,
                    LatePaymentFee = loan.LatePaymentFee,
                    PenaltyRate = loan.PenaltyRate,
                    Collateral = loan.Collateral,
                    Notes = loan.Notes
                };

                _viewModel.AllLoans.Add(newModel);
                _viewModel.Loans.Add(newModel);

                MessageBox.Show("Loan added successfully!", "Success", MessageBoxButton.OK);
            }

            _viewModel.SelectedLoan = null;
            _viewModel.CurrentLoan = new LoanFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}