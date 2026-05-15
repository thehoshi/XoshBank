using System;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;

namespace XoshBank.Command.Employees
{
    public class EditEmployeesCommand : ICommand
    {
        private readonly EmployeesControlViewModel _viewModel;

        public EditEmployeesCommand(EmployeesControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

      
        public bool CanExecute(object parameter) => _viewModel.SelectedEmployee != null;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to edit.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _viewModel.CurrentState = ViewState.Edit;
        }
    }
}
