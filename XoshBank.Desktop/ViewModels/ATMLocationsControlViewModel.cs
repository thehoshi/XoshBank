using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Command.ATMLocations;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.ViewModels
{
    public class ATMLocationsControlViewModel : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _db;

        public ATMLocationsControlViewModel(IUnitOfWork db)
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
                _currentState = value;
                OnPropertyChanged(nameof(CurrentState));
            }
        }

        private ATMLocationFormModel _currentlocation;

        public ATMLocationFormModel CurrentATMLocation 
        {
            get
            {
                return _currentlocation;
            } 
            set
            {
                _currentlocation = value;
                OnPropertyChanged(nameof(CurrentATMLocation));
            }
        }

        
        private ATMLocationUIModel _selectedLocation;

        public ATMLocationUIModel SelectedLocation
        {
            get {
                return _selectedLocation;
                }
            set
            {
                _selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
                if (value != null)
                {
                    CurrentState = ViewState.Selected;
                    CurrentATMLocation = new ATMLocationFormModel
                    {
                        Id = SelectedLocation.ID,
                        Name = SelectedLocation.Name,
                        City = SelectedLocation.City,
                        Address = SelectedLocation.Address,
                        IsActive = SelectedLocation.IsActive,
                    };
                }
                else
                {
                    CurrentState=ViewState.Default;
                    CurrentATMLocation = new ATMLocationFormModel(); 
                }
            }
        }
        public ObservableCollection<ATMLocationUIModel> Locations {  get; set; }

        #endregion


        #region Commands
        public AddATMLocationCommand AddATMLocationCommand => new AddATMLocationCommand(this);

        public EditATMLocationCommand EditATMLocationCommand => new EditATMLocationCommand(this);

        public RejectATMLocationCommand RejectATMLocationCommand => new RejectATMLocationCommand(this);

        public SaveATMLocationCommand SaveATMLocationCommand => new SaveATMLocationCommand(this);

        public DeleteATMLocationCommand DeleteATMLocationCommand => new DeleteATMLocationCommand(this);

        public ExportATMLocationCommand exportATMLocationCommand => new ExportATMLocationCommand(this);

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
