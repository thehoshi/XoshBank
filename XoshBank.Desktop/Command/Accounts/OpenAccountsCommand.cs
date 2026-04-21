using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;
using XoshBank.Desktop.ViewModels;
using XoshBank.Desktop.Views.UserControls;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.ViewModels;
using XoshBank.Views.UserControls;


namespace XoshBank.Command.Accounts
{
    public class OpenAccountsCommand : ICommand
    {
        private readonly IUnitOfWork _db;
        public OpenAccountsCommand(IUnitOfWork db)
        {
            _db = db;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            var accountsControl = new Views.UserControls.AccountsControl();

            var viewModel = new AccountsControlViewModel(_db);

            List<Account> accounts = _db.Accounts.GetAll();

            List<AccountUIModel> accountUIModels = new List<AccountUIModel>();

            int no = 1;
            foreach (Account account in accounts)
            {
                AccountUIModel accountUIModel = new AccountUIModel
                {
                    No = no++,
                    AccountNumber = account.AccountNumber,
                    
                };
                accountUIModels.Add(accountUIModel);
            }

            viewModel.AllAccounts = accountUIModels;
            viewModel.Accounts = new ObservableCollection<AccountUIModel>(accountUIModels);

            viewModel.CurrentAccount = new AccountFormModel();
            viewModel.CurrentState = ViewState.Default;

            accountsControl.DataContext = viewModel;

            Grid grid = (Grid)parameter;

            grid.Children.Clear();
            grid.Children.Add(accountsControl);
        }
    }
}
