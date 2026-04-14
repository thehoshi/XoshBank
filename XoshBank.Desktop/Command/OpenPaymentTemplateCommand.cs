using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Desktop.Views.UserControls;

namespace XoshBank.Command
{
    public class OpenPaymentTemplateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            PaymentTemplatesControl paymentTemplatesControl = new PaymentTemplatesControl();

            Grid grid = (Grid)parameter;

            grid.Children.Clear();
            grid.Children.Add(paymentTemplatesControl);
        }
    }
}
