using System;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;

namespace XoshBank.Command.Employees
{
    public class DeleteEmployeesCommand : ICommand
    {
        private readonly EmployeesControlViewModel _viewModel;

        public DeleteEmployeesCommand(EmployeesControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

       
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _viewModel.SelectedEmployee != null;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedEmployee == null) return;

            var result = MessageBox.Show("Are you sure you want to delete?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;

            _viewModel.Db.Employees.Delete(_viewModel.SelectedEmployee.EmployeeId);
            _viewModel.AllEmployees.Remove(_viewModel.SelectedEmployee);
            _viewModel.Employees.Remove(_viewModel.SelectedEmployee);

            _viewModel.SelectedEmployee = null;
            _viewModel.CurrentEmployee = new Models.EmployeeFormModel();
            _viewModel.CurrentState = ViewState.Default;

            MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButton.OK);
        }
    }
}
