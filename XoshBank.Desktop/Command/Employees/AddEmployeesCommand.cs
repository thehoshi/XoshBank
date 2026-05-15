using System;
using System.Linq;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Employees
{
    public class AddEmployeesCommand : ICommand
    {
        private readonly EmployeesControlViewModel _viewModel;

        public AddEmployeesCommand(EmployeesControlViewModel viewModel)
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
           
            _viewModel.SelectedEmployee = null;
            _viewModel.CurrentState = ViewState.Add;

            int nextId = _viewModel.Db.Employees.GetNextId();
            _viewModel.CurrentEmployee.EmployeeId = nextId;
        }
    }
}
