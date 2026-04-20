using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

        private ATMLocationFormModel _currentForm;

        public PaymentTemplateFormModel CurrentTemplate
        {
            get
            {
                return CurrentTemplate;
            }
            set
            {
                CurrentTemplate= value;
                OnPropertyChanged(nameof(CurrentTemplate));
            }
        }

    public ObservableCollection<PaymentTemplateUIModel> Templates { get; set; }

        #endregion




        #region Commands
        public AddPaymentTemplateCommand AddPaymentTemplateCommand => new AddPaymentTemplateCommand(this);

        public RejectPaymentTemplateCommand RejectPaymentTemplateCommand => new RejectPaymentTemplateCommand(this);

        public SavePaymentTemplateCommand savePaymentTemplateCommand => new SavePaymentTemplateCommand(this);

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
