using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XoshBank.Enums;
using XoshBank.ViewModels;

namespace XoshBank.Command.Customers
{
    public class EditCustomerCommand : ICommand
    {
        private readonly CustomersControlViewModel _viewModel;
        public EditCustomerCommand(CustomersControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to edit.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _viewModel.CurrentState = ViewState.Edit;
        }
    }
}