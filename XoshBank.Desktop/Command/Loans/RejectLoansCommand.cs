using System;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Loans
{
    public class RejectLoansCommand : ICommand
    {
        private readonly LoansControlViewModel _viewModel;

        public RejectLoansCommand(LoansControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _viewModel.SelectedLoan = null;
            _viewModel.CurrentLoan = new LoanFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}