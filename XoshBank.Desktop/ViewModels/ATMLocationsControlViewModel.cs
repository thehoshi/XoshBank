using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Command.ATMLocations;
using XoshBank.Models;

namespace XoshBank.ViewModels
{
    public class ATMLocationsControlViewModel : INotifyPropertyChanged
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
                _currentState = value;
                OnPropertyChanged(nameof(CurrentState));
            }
        }

        public ATMLocationFormModel CurrentATMLocation {  get; set; }

        public List<ATMLocationUIModel> Locations {  get; set; }

        public AddATMLocationCommand AddATMLocationCommand => new AddATMLocationCommand(this);

        public RejectATMLocationCommand RejectATMLocationCommand => new RejectATMLocationCommand(this);

        public SaveATMLocationCommand SaveATMLocationCommand => new SaveATMLocationCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
