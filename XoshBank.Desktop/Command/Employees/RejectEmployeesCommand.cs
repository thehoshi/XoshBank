using System;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Employees
{
    public class RejectEmployeesCommand : ICommand
    {
        private readonly EmployeesControlViewModel _viewModel;

        public RejectEmployeesCommand(EmployeesControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _viewModel.SelectedEmployee = null;
            _viewModel.CurrentEmployee = new EmployeeFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}
