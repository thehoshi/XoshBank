using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.ViewModels;

namespace XoshBank.Command.Accounts
{
    public class AddAccountCommand : ICommand
    {
        private readonly AccountsControlViewModel _viewModel;
        public AddAccountCommand(AccountsControlViewModel viewModel)
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
            _viewModel.SelectedAccount = null;
            _viewModel.CurrentState = ViewState.Add;

            int nextId = _viewModel.DB.Branches.GetNextId();
            _viewModel.CurrentAccount.AccountID = nextId;
        }
    }
}
