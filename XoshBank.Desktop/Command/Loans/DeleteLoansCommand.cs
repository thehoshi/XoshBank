using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Loans
{
    public class DeleteLoansCommand : ICommand
    {
        private readonly LoansControlViewModel _viewModel;

        public DeleteLoansCommand(LoansControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedLoan == null) return;

            var result = MessageBox.Show("Are you sure you want to delete this loan?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;

            int id = _viewModel.SelectedLoan.No;

            _viewModel.DB.Loans.Delete(id);

            var inAll = _viewModel.AllLoans.FirstOrDefault(l => l.No == id);
            var inFiltered = _viewModel.Loans.FirstOrDefault(l => l.No == id);

            if (inAll != null) _viewModel.AllLoans.Remove(inAll);
            if (inFiltered != null) _viewModel.Loans.Remove(inFiltered);

            _viewModel.SelectedLoan = null;
            _viewModel.CurrentLoan = new LoanFormModel();
            _viewModel.CurrentState = ViewState.Default;

            MessageBox.Show("Loan deleted successfully!", "Success", MessageBoxButton.OK);
        }
    }
}