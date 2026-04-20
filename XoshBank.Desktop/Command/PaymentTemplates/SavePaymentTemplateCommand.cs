using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Enums;
using XoshBank.Models;
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
            PaymentTemplate Template = new PaymentTemplate
            {
                TemplateName = viewModel.CurrentTemplate.TemplateName,
                ServiceName = viewModel.CurrentTemplate.ServiceName,
                CustomerCode = viewModel.CurrentTemplate.CustomerCode,
                Amount = viewModel.CurrentTemplate.Amount,
                IsActive = viewModel.CurrentTemplate.IsActive,

            };

            viewModel.DB.PaymentTemplates.Add(Template);

            //mapping from UI model to entity
            PaymentTemplateUIModel templateUIModel = new PaymentTemplateUIModel
            {
                TemplateName = Template.TemplateName,
                ServiceName = Template.ServiceName,
                Amount = Template.Amount,
                IsActive=Template.IsActive,
            };

            viewModel.Templates.Add(templateUIModel);

            viewModel.CurrentState = ViewState.Default;

            viewModel.CurrentTemplate = new PaymentTemplateFormModel();
        }
    }
}
