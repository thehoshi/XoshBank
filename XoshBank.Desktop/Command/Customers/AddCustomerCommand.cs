using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Desktop.Views.UserControls;
using XoshBank.Enums;
using XoshBank.ViewModels;

namespace XoshBank.Command.Customers
{
    public class AddCustomerCommand : ICommand
    {

        private readonly CustomersControlViewModel _viewModel;
        public AddCustomerCommand(CustomersControlViewModel viewModel)
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
            _viewModel.CurrentState = ViewState.Add;
        }
    }
}
