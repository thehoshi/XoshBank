using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Command.PaymentTemplates;
using XoshBank.Models;

namespace XoshBank.ViewModels
{
    public class PaymentTemplatesControlViewModel : INotifyPropertyChanged
    {
        private int _currentState = 1;

        public int CurrentState
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
    public List<PaymentTemplateUIModel> Templates { get; set; }

        public AddPaymentTemplateCommand AddPaymentTemplateCommand => new AddPaymentTemplateCommand(this);

        public RejectPaymentTemplateCommand RejectPaymentTemplateCommand => new RejectPaymentTemplateCommand(this);

        public SavePaymentTemplateCommand savePaymentTemplateCommand => new SavePaymentTemplateCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
