using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.Enums;
using XoshBank.ViewModels;

namespace XoshBank.Command.PaymentTemplates
{
    public class AddPaymentTemplateCommand : ICommand
    {
        private readonly PaymentTemplatesControlViewModel viewModel;

        public AddPaymentTemplateCommand(PaymentTemplatesControlViewModel viewModel)
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
            viewModel.CurrentState = ViewState.Add;
        }
    }
}
