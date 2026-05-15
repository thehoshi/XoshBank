using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XoshBank.Enums;
using XoshBank.ViewModels;

namespace XoshBank.Command.Accounts
{
    public class EditAccountCommand
    {
        private readonly AccountsControlViewModel _viewModel;
        public EditAccountCommand(AccountsControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (_viewModel.SelectedAccount == null)
            {
                MessageBox.Show("Please select a customer to edit.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _viewModel.CurrentState = ViewState.Edit;
        }
    }
}
