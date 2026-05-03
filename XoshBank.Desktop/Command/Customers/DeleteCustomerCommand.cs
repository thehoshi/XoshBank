using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.ViewModels;

namespace XoshBank.Command.Customers
{
    public class DeleteCustomerCommand : ICommand
    {
        private readonly CustomersControlViewModel _viewModel;
        public DeleteCustomerCommand(CustomersControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedCustomer == null) return;

            var result = MessageBox.Show("Are you sure you want to delete this customer?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;

            int id = _viewModel.SelectedCustomer.ID;
            int index = _viewModel.Customers.IndexOf(_viewModel.SelectedCustomer);

            _viewModel.DB.Customers.Delete(id);

            var inAll = _viewModel.AllCustomers.FirstOrDefault(b => b.ID == id);
            var inFiltered = _viewModel.Customers.FirstOrDefault(b => b.ID == id);

            if (inAll != null) _viewModel.AllCustomers.Remove(inAll);
            if (inFiltered != null) _viewModel.Customers.Remove(inFiltered);        
            _viewModel.SelectedCustomer = null;
            _viewModel.CurrentCustomer = new CustomerFormModel();
            _viewModel.CurrentState = ViewState.Default;

            MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButton.OK);
        }
    }
}