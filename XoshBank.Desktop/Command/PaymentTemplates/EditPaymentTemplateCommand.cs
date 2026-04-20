using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.Enums;
using XoshBank.ViewModels;

namespace XoshBank.Command.PaymentTemplates
{
    public class EditPaymentTemplateCommand : ICommand
    {
        private readonly PaymentTemplatesControlViewModel _viewModel;

        public EditPaymentTemplateCommand(PaymentTemplatesControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.CurrentState = ViewState.Edit;
        }
    }
}
