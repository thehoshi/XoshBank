using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Command.Branches;
using XoshBank.Command.Customers;
using XoshBank.Core.Repositories;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.ViewModels
{
    public class CustomersControlViewModel : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _db;
        public CustomersControlViewModel(IUnitOfWork db)
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

        private CustomerFormModel _currentCustomer;
        public CustomerFormModel CurrentCustomer
        {
            get => _currentCustomer;
            set { _currentCustomer = value; OnPropertyChanged(nameof(CurrentCustomer)); }
        }
        private CustomerUIModel _selectedCustomer;
        public CustomerUIModel SelectedCustomer 
        {
            get => _selectedCustomer; 
            set 
            { _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
                if (value != null)
                {
                    CurrentState = ViewState.Selected;
                    CurrentCustomer = new CustomerFormModel
                    {
                        ID = SelectedCustomer.ID,
                        FirstName = SelectedCustomer.FirstName,
                        LastName = SelectedCustomer.LastName,
                        DateOfBirth = SelectedCustomer.DateOfBirth,
                        Email = SelectedCustomer.Email,
                        PhoneNumber = SelectedCustomer.PhoneNumber,
                        Address = SelectedCustomer.Address,
                        FINCode = SelectedCustomer.FINCode,
                        CreatedAt = SelectedCustomer.CreatedAt

                    };
                }
                else
                {
                    CurrentState = ViewState.Default;
                    CurrentCustomer = new CustomerFormModel(); 
                }
            }

        }
        private ObservableCollection<CustomerUIModel> _customers;
        public ObservableCollection<CustomerUIModel> Customers
        {
            get => _customers;
            set { _customers = value; OnPropertyChanged(nameof(Customers)); }
        }

        public List<CustomerUIModel> AllCustomers { get; set; }

        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));

                var filtered = new List<CustomerUIModel>();

                if (string.IsNullOrWhiteSpace(SearchValue))
                {
                    Customers = new ObservableCollection<CustomerUIModel>(AllCustomers);
                }
                else
                {
                    var upper = SearchValue.ToUpper();
                    foreach (CustomerUIModel a in AllCustomers)
                    {
                        if (a.FirstName?.ToUpper().Contains(upper) == true ||
                            a.LastName?.ToUpper().Contains(upper) == true ||
                            a.Email?.ToUpper().Contains(upper) == true || a.Address?.ToUpper().Contains(upper)==true
                            || a.FINCode?.ToUpper().Contains(upper) == true || a.DateOfBirth.ToString("dd.MM.yyyy").Contains(upper))
                        {
                            filtered.Add(a);
                        }
                    }
                    Customers = new ObservableCollection<CustomerUIModel>(filtered);
                }
            }
        }
        #endregion

        #region commands

        public AddCustomerCommand AddCommand => new AddCustomerCommand  (this);
        public SaveCustomerCommand SaveCommand => new SaveCustomerCommand(this);
        public EditCustomerCommand EditCommand => new EditCustomerCommand(this);
        public RejectCustomerCommand RejectCommand => new RejectCustomerCommand(this);
        public DeleteCustomerCommand DeleteCommand => new DeleteCustomerCommand(this);
        public ExportCustomerCommand ExportCommand => new ExportCustomerCommand(this);

        #endregion

        #region propertychanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
