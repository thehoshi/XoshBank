using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.Views.UserControls;

namespace XoshBank.Command.Loans
{
    public class OpenLoansCommand : ICommand
    {
        private readonly IUnitOfWork _db;

        public OpenLoansCommand(IUnitOfWork db)
        {
            _db = db;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            LoansControl loansControl = new LoansControl();

            LoansControlViewModel viewModel = new LoansControlViewModel(_db);

            List<Loan> loans = _db.Loans.GetAll();
            List<LoanUIModel> loanUIModels = new List<LoanUIModel>();

            foreach (Loan loan in loans)
            {
                loanUIModels.Add(new LoanUIModel
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
                });
            }

            viewModel.AllLoans = loanUIModels;
            viewModel.Loans = new ObservableCollection<LoanUIModel>(loanUIModels);
            viewModel.CurrentLoan = new LoanFormModel();
            viewModel.CurrentState = ViewState.Default;

            loansControl.DataContext = viewModel;

            Grid grid = (Grid)parameter;
            grid.Children.Clear();
            grid.Children.Add(loansControl);
        }
    }
}