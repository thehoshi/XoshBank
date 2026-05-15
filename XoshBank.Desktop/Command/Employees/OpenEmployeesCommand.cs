using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;
using XoshBank.Desktop.ViewModels;
using XoshBank.Desktop.Views.UserControls;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Employees
{
    public class OpenEmployeesCommand : ICommand
    {
        private readonly IUnitOfWork _db;

        public OpenEmployeesCommand(IUnitOfWork db)
        {
            _db = db;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
           
            EmployeesControl employeesControl = new EmployeesControl(_db);

           
            EmployeesControlViewModel viewModel = (EmployeesControlViewModel)employeesControl.DataContext;

           
            List<Employee> employees = _db.Employees.GetAll().ToList();

            
            List<EmployeeUIModel> employeeUIModels = new List<EmployeeUIModel>();
            foreach (Employee emp in employees)
            {
                employeeUIModels.Add(new EmployeeUIModel
                {
                    EmployeeId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Email = emp.Email,
                    Phone = emp.Phone,
                    Position = emp.Position,
                    Salary = emp.Salary,
                    HireDate = emp.HireDate,
                    IsActive = emp.IsActive,
                    DeletedAt = emp.DeletedAt
                });
            }

            
            viewModel.AllEmployees = employeeUIModels;
            viewModel.Employees = new ObservableCollection<EmployeeUIModel>(employeeUIModels);
            viewModel.CurrentEmployee = new EmployeeFormModel();
            viewModel.CurrentState = ViewState.Default;

           
            if (parameter is Grid grid)
            {
                grid.Children.Clear();
                grid.Children.Add(employeesControl);
            }
        }
    }
}
