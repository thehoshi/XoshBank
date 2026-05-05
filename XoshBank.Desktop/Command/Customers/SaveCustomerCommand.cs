using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.ViewModels;

namespace XoshBank.Command.Customers
{
    public class SaveCustomerCommand : ICommand
    {
        private readonly CustomersControlViewModel _viewModel;
        public SaveCustomerCommand(CustomersControlViewModel viewModel)
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

            var source = _viewModel.CurrentCustomer ?? new CustomerFormModel();

            var customer = new Customer
            {
                ID = source.ID,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                PhoneNumber = source.PhoneNumber,
                FINCode = source.FINCode,
                Address = source.Address,
                Email = source.Email,
                CreatedAt = DateTime.Now
            };
            var isEdit = _viewModel.SelectedCustomer != null && _viewModel.SelectedCustomer.ID > 0
              && _viewModel.CurrentState == ViewState.Edit;
            if (isEdit)
            {
                customer.ID = _viewModel.SelectedCustomer.ID;
                _viewModel.DB.Customers.Update(customer);
                int index = _viewModel.Customers.IndexOf(_viewModel.SelectedCustomer);
                var updated = new CustomerUIModel
                {
                    ID = customer.ID,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    PhoneNumber = customer.PhoneNumber,
                    FINCode = customer.FINCode,
                    Address = customer.Address,
                    Email = customer.Email,
                    CreatedAt = customer.CreatedAt
                };
                if (index >= 0)
                {
                    _viewModel.AllCustomers[index] = updated;
                    _viewModel.Customers[index] = updated;
                }
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButton.OK);
            }
            else
            {
                _viewModel.DB.Customers.Insert(customer);
                var newModel = new CustomerUIModel
                {
                    ID = customer.ID,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    PhoneNumber = customer.PhoneNumber,
                    FINCode = customer.FINCode,
                    Address = customer.Address,
                    Email = customer.Email,
                    CreatedAt = customer.CreatedAt
                };
                _viewModel.AllCustomers.Add(newModel);
                _viewModel.Customers.Add(newModel);
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK);
            }
            _viewModel.SelectedCustomer = null;
            _viewModel.CurrentCustomer = new CustomerFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}
