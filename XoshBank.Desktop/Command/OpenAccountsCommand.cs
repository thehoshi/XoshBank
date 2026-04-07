using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Views.UserControl;


namespace XoshBank.Command
{
    public class OpenAccountsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CustomersControl customersControl = new CustomersControl();

            Grid grid = (Grid)parameter;

            grid.Children.Clear();
            grid.Children.Add(customersControl);
        }
    }
}
