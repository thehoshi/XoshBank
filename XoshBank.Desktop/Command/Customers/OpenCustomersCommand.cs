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


namespace XoshBank.Command.Customers
{
    public class OpenCustomersCommand : ICommand
    {
        private readonly IUnitOfWork _db;
        public OpenCustomersCommand(IUnitOfWork db)
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
            CustomersControl customersControl = new CustomersControl();

            CustomersControlViewModel viewModel = new CustomersControlViewModel(_db);

            List<Customer> customers = _db.Customers.GetAll();

            List<CustomerUIModel> customerUIModels = new List<CustomerUIModel>();

            foreach (Customer customer in customers)
            {
                CustomerUIModel customerUIModel = new CustomerUIModel
                {
                    ID = customerUIModels.Count + 1,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email,
                    DateOfBirth = customer.DateOfBirth,
                    FINCode = customer.FINCode
                };
                customerUIModels.Add(customerUIModel);
            }

            viewModel.AllCustomers = customerUIModels;
            viewModel.Customers = new ObservableCollection<CustomerUIModel>(customerUIModels);

            viewModel.CurrentCustomer = new CustomerFormModel();
            viewModel.CurrentState = ViewState.Default;

            customersControl.DataContext = viewModel;

            Grid grid = (Grid)parameter;

            grid.Children.Clear();
            grid.Children.Add(customersControl);
        }
    }
}
