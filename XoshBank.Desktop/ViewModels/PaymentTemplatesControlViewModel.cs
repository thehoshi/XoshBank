using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Models;

namespace XoshBank.ViewModels
{
    public class PaymentTemplatesControlViewModel
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
            }
        }
    public List<PaymentTemplateUIModel> Templates { get; set; }
    }

}
