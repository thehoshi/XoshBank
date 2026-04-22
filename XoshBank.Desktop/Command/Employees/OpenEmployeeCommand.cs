using System;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Desktop.Views.UserControls;

namespace XoshBank.Command
{
    public class OpenEmployeeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            EmployeesControl employeesControl = new EmployeesControl();

            Grid grid = (Grid)parameter;

            grid.Children.Clear();
            grid.Children.Add(employeesControl);
        }
    }
}

