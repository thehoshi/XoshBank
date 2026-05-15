using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.ViewModels;

namespace XoshBank.Command.Accounts
{
    public class RejectAccountCommand
    {
        private readonly AccountsControlViewModel _viewModel;
        public RejectAccountCommand(AccountsControlViewModel viewModel)
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
            _viewModel.CurrentAccount = new AccountFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}
