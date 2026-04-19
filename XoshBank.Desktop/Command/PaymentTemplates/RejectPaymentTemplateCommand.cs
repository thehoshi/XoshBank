using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.ViewModels;

namespace XoshBank.Command.PaymentTemplates
{
    public class RejectPaymentTemplateCommand : ICommand
    {
        private readonly PaymentTemplatesControlViewModel viewModel;

        public RejectPaymentTemplateCommand(PaymentTemplatesControlViewModel viewModel)
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
            viewModel.CurrentState = 1;
        }
    }
}
