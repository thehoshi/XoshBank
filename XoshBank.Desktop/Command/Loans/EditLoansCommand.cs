using System;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;

namespace XoshBank.Command.Loans
{
    public class EditLoansCommand : ICommand
    {
        private readonly LoansControlViewModel _viewModel;

        public EditLoansCommand(LoansControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedLoan == null)
            {
                MessageBox.Show("Please select a loan to edit.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _viewModel.CurrentState = ViewState.Edit;
        }
    }
}