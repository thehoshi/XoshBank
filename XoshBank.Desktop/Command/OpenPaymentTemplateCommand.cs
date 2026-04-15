using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;
using XoshBank.Desktop.Views.UserControls;
using XoshBank.Models;
using XoshBank.ViewModels;


namespace XoshBank.Command
{
    public class OpenPaymentTemplateCommand : ICommand
    {
        public readonly IUnitOfWork _db;

        public OpenPaymentTemplateCommand(IUnitOfWork db)
        {
            _db = db;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            List<PaymentTemplate> Templates = _db.PaymentTemplates.GetAll();

            List<PaymentTemplateUIModel> TemplatesUIModel = new List<PaymentTemplateUIModel>();

            foreach(PaymentTemplate Template in Templates)
            {
                PaymentTemplateUIModel paymentTemplateUIModel = new PaymentTemplateUIModel
                {
                    TemplateName = Template.TemplateName,
                    ServiceName = Template.ServiceName,
                    Amount = Template.Amount
                };

            }
            PaymentTemplatesControl paymentTemplatesControl = new PaymentTemplatesControl();

            PaymentTemplatesControlViewModel viewModel = new PaymentTemplatesControlViewModel();

            paymentTemplatesControl.DataContext = viewModel;

            Grid grid = (Grid)parameter;

            grid.Children.Clear();
            grid.Children.Add(paymentTemplatesControl);
        }
    }
}
