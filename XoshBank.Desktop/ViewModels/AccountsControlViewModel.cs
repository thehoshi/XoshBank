using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Command.Accounts;
using XoshBank.Command.Branches;
using XoshBank.Command.Customers;
using XoshBank.Core.Repositories;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.ViewModels
{
    public class AccountsControlViewModel : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _db;
        public AccountsControlViewModel(IUnitOfWork db)
        {
            _db = db;
        }

        #region properties

        public IUnitOfWork DB => _db;

        private ViewState _currentState;
        public ViewState CurrentState
        {
            get => _currentState;
            set { _currentState = value; OnPropertyChanged(nameof(CurrentState)); }
        }

        private AccountFormModel _currentAccount;
        public AccountFormModel CurrentAccount
        {
            get => _currentAccount;
            set { _currentAccount = value; OnPropertyChanged(nameof(CurrentAccount)); }
        }

        private AccountUIModel _selectedAccount;
        public AccountUIModel SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                OnPropertyChanged(nameof(SelectedAccount));

                if (value != null)
                {
                    CurrentState = ViewState.Selected;
                    CurrentAccount = new AccountFormModel
                    {
                        CustomerID = SelectedAccount.CustomerID,
                        AccountNumber = SelectedAccount.AccountNumber,
                        Balance = SelectedAccount.Balance,
                        AccountType = SelectedAccount.AccountType,
                        Currency = SelectedAccount.Currency
                    };
                }
                else
                {
                    CurrentState = ViewState.Default;
                    CurrentAccount = new AccountFormModel();
                }
            }
        }

        private ObservableCollection<AccountUIModel> _accounts;
        public ObservableCollection<AccountUIModel> Accounts
        {
            get => _accounts;
            set { _accounts = value; OnPropertyChanged(nameof(Accounts)); }
        }

        public List<AccountUIModel> AllAccounts { get; set; }

        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));

                var filtered = new List<AccountUIModel>();

                if (string.IsNullOrWhiteSpace(SearchValue))
                {
                    Accounts = new ObservableCollection<AccountUIModel>(AllAccounts);
                }
                else
                {
                    var upper = SearchValue.ToUpper();
                    foreach (AccountUIModel b in AllAccounts)
                    {
                        if (b.AccountNumber?.ToUpper().Contains(upper) == true )
                        {
                            filtered.Add(b);
                        }
                    }
                    Accounts = new ObservableCollection<AccountUIModel>(filtered);
                }
            }
        }

        #endregion

        #region property changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #region commands
        public AddAccountCommand AddCommand => new AddAccountCommand(this);
        public SaveAccountCommand SaveCommand => new SaveAccountCommand(this);
        public EditAccountCommand EditCommand => new EditAccountCommand(this);
        public RejectAccountCommand RejectCommand => new RejectAccountCommand(this);
        public DeleteAccountCommand DeleteCommand => new DeleteAccountCommand(this);
        #endregion
    }
}
