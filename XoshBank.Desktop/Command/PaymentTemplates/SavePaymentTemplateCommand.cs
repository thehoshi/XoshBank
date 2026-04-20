using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to save it?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult != MessageBoxResult.Yes)
                return;

            PaymentTemplate Template = new PaymentTemplate
            {
                ID = viewModel.SelectedTemplate.ID, 
                TemplateName = viewModel.SelectedTemplate.TemplateName,
                ServiceName = viewModel.SelectedTemplate.ServiceName,
                CustomerCode = viewModel.SelectedTemplate.CustomerCode,
                Amount = viewModel.SelectedTemplate.Amount,
                IsActive = viewModel.SelectedTemplate.IsActive,

            };

            if (viewModel.CurrentTemplate.Id > 0)
            {
                viewModel.DB.PaymentTemplates.Update(Template);

                PaymentTemplateUIModel updatedTemplateUIModel = new PaymentTemplateUIModel
                {
                    ID = Template.ID,
                    TemplateName = Template.TemplateName,
                    ServiceName = Template.ServiceName,
                    Amount = Template.Amount,
                    IsActive = Template.IsActive,
                };

                int selectedTemplateIndex = viewModel.SelectedTemplate.No - 1;
                viewModel.Templates[selectedTemplateIndex] = updatedTemplateUIModel;
            }
            else
            {
                viewModel.DB.PaymentTemplates.Add(Template);
                PaymentTemplateUIModel newtemplateUIModel = new PaymentTemplateUIModel
                {
                    ID = Template.ID,
                    TemplateName = Template.TemplateName,
                    ServiceName = Template.ServiceName,
                    Amount = Template.Amount,
                    IsActive = Template.IsActive,
                };

            }



            //mapping from UI model to entity
            PaymentTemplateUIModel templateUIModel = new PaymentTemplateUIModel
            {
                ID = Template.ID,
                TemplateName = Template.TemplateName,
                ServiceName = Template.ServiceName,
                Amount = Template.Amount,
                IsActive = Template.IsActive
            };

            viewModel.Templates.Add(templateUIModel);

            viewModel.CurrentState = ViewState.Default;

            viewModel.SelectedTemplate = new PaymentTemplateUIModel();

            MessageBox.Show("Template saved successfully!", "Succsess", MessageBoxButton.OK);

        }
    }
}
