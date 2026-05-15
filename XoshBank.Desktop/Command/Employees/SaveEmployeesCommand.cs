using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.Core.Entities;

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
            if (_viewModel.CurrentEmployee == null) return;

            try
            {
                var entity = new Employee
                {
                    EmployeeId = _viewModel.CurrentEmployee.EmployeeId,
                    FirstName = _viewModel.CurrentEmployee.FirstName,
                    LastName = _viewModel.CurrentEmployee.LastName,
                    Email = _viewModel.CurrentEmployee.Email,
                    Phone = _viewModel.CurrentEmployee.Phone,
                    Position = _viewModel.CurrentEmployee.Position,
                    Salary = _viewModel.CurrentEmployee.Salary,
                    HireDate = _viewModel.CurrentEmployee.HireDate,
                    IsActive = _viewModel.CurrentEmployee.IsActive,
                    DeletedAt = _viewModel.CurrentEmployee.DeletedAt
                };

                if (_viewModel.CurrentState == ViewState.Add)
                {
                    _viewModel.Db.Employees.Insert(entity);

                    var uiModel = new EmployeeUIModel
                    {
                        EmployeeId = entity.EmployeeId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Phone = entity.Phone,
                        Position = entity.Position,
                        Salary = entity.Salary,
                        HireDate = entity.HireDate,
                        IsActive = entity.IsActive,
                        DeletedAt = entity.DeletedAt
                    };

                    _viewModel.AllEmployees.Add(uiModel);
                    _viewModel.Employees.Add(uiModel);

                    MessageBox.Show("Employee added successfully!", "Success", MessageBoxButton.OK);
                }
                else if (_viewModel.CurrentState == ViewState.Edit)
                {
                    _viewModel.Db.Employees.Update(entity);

                    var existing = _viewModel.AllEmployees.FirstOrDefault(e => e.EmployeeId == entity.EmployeeId);
                    if (existing != null)
                    {
                        existing.FirstName = entity.FirstName;
                        existing.LastName = entity.LastName;
                        existing.Email = entity.Email;
                        existing.Phone = entity.Phone;
                        existing.Position = entity.Position;
                        existing.Salary = entity.Salary;
                        existing.HireDate = entity.HireDate;
                        existing.IsActive = entity.IsActive;
                        existing.DeletedAt = entity.DeletedAt;
                    }

                    MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButton.OK);
                }

                _viewModel.SelectedEmployee = null;
                _viewModel.CurrentEmployee = new EmployeeFormModel();
                _viewModel.CurrentState = ViewState.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving employee: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
