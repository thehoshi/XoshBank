using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.ViewModels;

namespace XoshBank.Command.PaymentTemplates
{
    public class SavePaymentTemplateCommand : ICommand
    {
        private readonly PaymentTemplatesControlViewModel viewModel;

        public SavePaymentTemplateCommand(PaymentTemplatesControlViewModel viewModel)
        {
            viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
