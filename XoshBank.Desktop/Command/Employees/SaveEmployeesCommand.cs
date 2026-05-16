using System;
using System.Windows;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Employees
{
    public class SaveEmployeesCommand : ICommand
    {
        private readonly EmployeesControlViewModel _viewModel;

        public SaveEmployeesCommand(EmployeesControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var result = MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) return;

            var source = _viewModel.CurrentEmployee;

            var employee = new Employee
            {
                EmployeeId = source.EmployeeId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                Phone = source.Phone,
                Position = source.Position,
                Salary = source.Salary,
                HireDate = source.HireDate,
                IsActive = source.IsActive
            };

            bool isEdit = _viewModel.SelectedEmployee != null && _viewModel.SelectedEmployee.EmployeeId > 0;

            if (isEdit)
            {
                _viewModel.Db.Employees.Update(employee);

                int index = _viewModel.Employees.IndexOf(_viewModel.SelectedEmployee);
                var updated = new EmployeeUIModel
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Position = employee.Position,
                    Salary = employee.Salary,
                    HireDate = employee.HireDate,
                    IsActive = employee.IsActive
                };

                if (index >= 0)
                {
                    _viewModel.AllEmployees[index] = updated;
                    _viewModel.Employees[index] = updated;
                }

                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButton.OK);
            }
            else
            {
                _viewModel.Db.Employees.Insert(employee);

                var newModel = new EmployeeUIModel
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Position = employee.Position,
                    Salary = employee.Salary,
                    HireDate = employee.HireDate,
                    IsActive = employee.IsActive
                };

                _viewModel.AllEmployees.Add(newModel);
                _viewModel.Employees.Add(newModel);

                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButton.OK);
            }

            _viewModel.SelectedEmployee = null;
            _viewModel.CurrentEmployee = new EmployeeFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}

