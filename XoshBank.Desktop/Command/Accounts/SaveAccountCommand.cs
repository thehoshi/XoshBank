using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XoshBank.Core.Entities;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.ViewModels;

namespace XoshBank.Command.Accounts
{
    public class SaveAccountCommand
    {
        private readonly AccountsControlViewModel _viewModel;
        public SaveAccountCommand(AccountsControlViewModel viewModel)
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
            var result = MessageBox.Show("Are you sure you want to save?",
                            "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;

            var source = _viewModel.CurrentAccount ?? new AccountFormModel();

            var account = new Account
            {
                ID = source.AccountID,
                CustomerID = source.CustomerID,
                AccountNumber = source.AccountNumber,
                Balance = source.Balance,
                AccountType = source.AccountType,
                Currency = source.Currency,
                CreatedAt = DateTime.Now
            };
            var isEdit = _viewModel.SelectedAccount != null && _viewModel.SelectedAccount.AccountID > 0
              && _viewModel.CurrentState == ViewState.Edit;
            if (isEdit)
            {
                account.ID = _viewModel.SelectedAccount.AccountID;
                _viewModel.DB.Accounts.Update(account);
                int index = _viewModel.Accounts.IndexOf(_viewModel.SelectedAccount);
                var updated = new AccountUIModel
                {
                    No = _viewModel.SelectedAccount.No,
                    AccountID = account.ID,
                    CustomerID = account.CustomerID,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    AccountType = account.AccountType,
                    Currency = account.Currency,                   
                };
                if (index >= 0)
                {
                    _viewModel.AllAccounts[index] = updated;
                    _viewModel.Accounts[index] = updated;
                }
                MessageBox.Show("Account updated successfully!", "Success", MessageBoxButton.OK);
            }
            else
            {
                _viewModel.DB.Accounts.Insert(account);
                var newModel = new AccountUIModel
                {
                    No = _viewModel.AllAccounts.Count + 1,
                    AccountID = account.ID,
                    CustomerID = account.CustomerID,
                    AccountNumber = account.AccountNumber,
                    Balance  = account.Balance,
                    AccountType = account.AccountType,
                    Currency = account.Currency,

                };
                _viewModel.AllAccounts.Add(newModel);
                _viewModel.Accounts.Add(newModel);
                MessageBox.Show("Account added successfully!", "Success", MessageBoxButton.OK);
            }
            _viewModel.SelectedAccount = null;
            _viewModel.CurrentAccount = new AccountFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}
