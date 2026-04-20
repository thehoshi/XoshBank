using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Command.PaymentTemplates;
using XoshBank.Core.Repositories;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.ViewModels
{
    public class PaymentTemplatesControlViewModel : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _db;

        public PaymentTemplatesControlViewModel(IUnitOfWork db)
        {
            _db = db;

        }

        #region Properties

        public IUnitOfWork DB => _db;

        private ViewState _currentState;

        public ViewState CurrentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                _currentState= value;
                OnPropertyChanged(nameof(CurrentState));
                
            }
        }

        private PaymentTemplateFormModel _currentTemplate;

        public PaymentTemplateFormModel CurrentTemplate
        {
            get
            {
                return _currentTemplate;
            }
            set
            {
                _currentTemplate = value;
                OnPropertyChanged(nameof(_currentTemplate));
            }
        }

        private PaymentTemplateUIModel _selectedTemplate;

        public PaymentTemplateUIModel SelectedTemplate
        {
            get
            {
                return _selectedTemplate;
            }
            set
            {
                _selectedTemplate = value;
                OnPropertyChanged(nameof(_selectedTemplate));
                if (value != null)
                {
                    CurrentState = ViewState.Selected;
                    CurrentTemplate = new PaymentTemplateFormModel
                    {
                        Id = SelectedTemplate.ID,
                        TemplateName = SelectedTemplate.TemplateName,
                        ServiceName = SelectedTemplate.ServiceName,
                        CustomerCode = SelectedTemplate.CustomerCode,
                        Amount = SelectedTemplate.Amount,
                        IsActive = SelectedTemplate.IsActive,
                    };
                }
                else
                {
                    CurrentState = ViewState.Default;
                    CurrentTemplate = new PaymentTemplateFormModel();
                }
            }
        }
    public ObservableCollection<PaymentTemplateUIModel> Templates { get; set; }

        #endregion




        #region Commands
        public AddPaymentTemplateCommand AddPaymentTemplateCommand => new AddPaymentTemplateCommand(this);

        public EditPaymentTemplateCommand EditPaymentTemplateCommand => new EditPaymentTemplateCommand(this);
        public RejectPaymentTemplateCommand RejectPaymentTemplateCommand => new RejectPaymentTemplateCommand(this);

        public SavePaymentTemplateCommand savePaymentTemplateCommand => new SavePaymentTemplateCommand(this);

        public DeletePaymentTemplateCommand deletePaymentTemplateCommand => new DeletePaymentTemplateCommand(this);

        public ExportPaymentTemplateCommand exportPaymentTemplateCommand => new ExportPaymentTemplateCommand(this);

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
