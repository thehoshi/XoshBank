using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Command;
using XoshBank.Desktop.Views.UserControls;
using XoshBank.Entities;
using XoshBank.Views.UserControls;

namespace XoshBank.Command
{
    public class OpenEmployeesCommand : ICommand
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

