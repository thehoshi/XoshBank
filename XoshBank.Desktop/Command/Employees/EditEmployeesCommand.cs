using System;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Employees
{
    public class EditEmployeesCommand : ICommand
    {
        private readonly EmployeesControlViewModel _viewModel;

        public EditEmployeesCommand(EmployeesControlViewModel viewModel)
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

            _viewModel.CurrentState = ViewState.Edit;

            _viewModel.CurrentEmployee = new EmployeeFormModel
            {
                EmployeeId = _viewModel.SelectedEmployee.EmployeeId,
                FirstName = _viewModel.SelectedEmployee.FirstName,
                LastName = _viewModel.SelectedEmployee.LastName,
                Email = _viewModel.SelectedEmployee.Email,
                Phone = _viewModel.SelectedEmployee.Phone,
                Position = _viewModel.SelectedEmployee.Position,
                Salary = _viewModel.SelectedEmployee.Salary ?? 0,
                HireDate = _viewModel.SelectedEmployee.HireDate ?? DateTime.Now,
                IsActive = _viewModel.SelectedEmployee.IsActive ?? false,
                DeletedAt = _viewModel.SelectedEmployee.DeletedAt
            };
        }
    }
}
