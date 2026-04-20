using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XoshBank.ViewModels;

namespace XoshBank.Command.PaymentTemplates
{
    public class DeletePaymentTemplateCommand : ICommand
    {
        private readonly PaymentTemplatesControlViewModel _viewModel;

        public DeletePaymentTemplateCommand(PaymentTemplatesControlViewModel viewModel)
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
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to delete it?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult != MessageBoxResult.Yes)
                return;

            int id = _viewModel.SelectedTemplate.ID;

           _viewModel.DB.PaymentTemplates.Delete(id);

            MessageBox.Show("Templates deleted successfully!", "Succsess", MessageBoxButton.OK);

        }
    }
}
