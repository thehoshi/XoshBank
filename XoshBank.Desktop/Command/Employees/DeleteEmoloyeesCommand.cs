using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Employees
{
    public class DeleteEmployeesCommand : ICommand
    {
        private readonly EmployeesControlViewModel _viewModel;

        public DeleteEmployeesCommand(EmployeesControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

       
        public bool CanExecute(object parameter) => _viewModel.SelectedEmployee != null;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedEmployee == null) return;

            var result = MessageBox.Show("Are you sure you want to delete this employee?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;

            int id = _viewModel.SelectedEmployee.EmployeeId;

           
            _viewModel.Db.Employees.Delete(id);

           
            var inAll = _viewModel.AllEmployees.FirstOrDefault(e => e.EmployeeId == id);
            var inFiltered = _viewModel.Employees.FirstOrDefault(e => e.EmployeeId == id);

            if (inAll != null) _viewModel.AllEmployees.Remove(inAll);
            if (inFiltered != null) _viewModel.Employees.Remove(inFiltered);

       
            _viewModel.SelectedEmployee = null;
            _viewModel.CurrentEmployee = new EmployeeFormModel();
            _viewModel.CurrentState = ViewState.Default;

            MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButton.OK);
        }
    }
}
