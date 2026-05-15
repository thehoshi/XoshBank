using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.ViewModels;

namespace XoshBank.Command.Accounts
{
    public class DeleteAccountCommand
    {
        private readonly AccountsControlViewModel _viewModel;
        public DeleteAccountCommand(AccountsControlViewModel viewModel)
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

            if (_viewModel.SelectedAccount == null) return;

            var result = MessageBox.Show("Are you sure you want to delete this account?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;

            int id = _viewModel.SelectedAccount.AccountID;
            int index = _viewModel.Accounts.IndexOf(_viewModel.SelectedAccount);

            _viewModel.DB.Accounts.Delete(id);

            var inAll = _viewModel.AllAccounts.FirstOrDefault(b => b.AccountID == id);
            var inFiltered = _viewModel.Accounts.FirstOrDefault(b => b.AccountID == id);

            if (inAll != null) _viewModel.AllAccounts.Remove(inAll);
            if (inFiltered != null) _viewModel.Accounts.Remove(inFiltered);
            _viewModel.SelectedAccount = null;
            _viewModel.CurrentAccount = new AccountFormModel();
            _viewModel.CurrentState = ViewState.Default;

            MessageBox.Show("Account deleted successfully!", "Success", MessageBoxButton.OK);
        }
    }
}
