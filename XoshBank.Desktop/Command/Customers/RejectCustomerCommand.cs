using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.ViewModels;

namespace XoshBank.Command.Customers
{
    public class RejectCustomerCommand : ICommand
    {
        private readonly CustomersControlViewModel _viewModel;
        public RejectCustomerCommand(CustomersControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _viewModel.SelectedCustomer = null;
            _viewModel.CurrentCustomer = new CustomerFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}