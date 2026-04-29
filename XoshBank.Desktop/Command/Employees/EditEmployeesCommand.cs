using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;

namespace XoshBank.Command.Employees
{
    public class EditEmployeesCommand
    {
        private readonly EmployeesControlViewModel _viewModel;
        public EditEmployeesCommand(EmployeesControlViewModel viewModel)
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
            _viewModel.CurrentState = ViewState.Edit;
        }
    }
}
