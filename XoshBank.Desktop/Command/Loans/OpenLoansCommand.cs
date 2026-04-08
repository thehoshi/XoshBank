using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Desktop.Views.UserControls;

namespace XoshBank.Command.Loans
{
    public class OpenLoansCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LoansControl loansControl = new LoansControl();

            Grid grid = (Grid)parameter;

            grid.Children.Clear();
            grid.Children.Add(loansControl);
        }

    }
}
