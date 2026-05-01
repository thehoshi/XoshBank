using DocumentFormat.OpenXml.Office2010.Excel;
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

        private ViewState _currentState = ViewState.Default;

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
                OnPropertyChanged(nameof(IsAddEnabled));
                OnPropertyChanged(nameof(IsEditDeleteEnabled));
                OnPropertyChanged(nameof(IsSaveRejectEnabled));


            }
        }

        public bool IsAddEnabled => CurrentState == ViewState.Default || CurrentState == ViewState.Selected;
        public bool IsEditDeleteEnabled => CurrentState == ViewState.Selected;
        public bool IsSaveRejectEnabled => CurrentState == ViewState.Add || CurrentState == ViewState.Edit;


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

        private ObservableCollection<ATMLocationUIModel> _locations;
        public ObservableCollection<ATMLocationUIModel> Locations
        {
            get
            {
                return _locations;
            }
            set
            {
                _locations = value;
                OnPropertyChanged(nameof(Locations));
            }
        }

        public List<ATMLocationUIModel> Alllocations { get; set; }

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));

                List<ATMLocationUIModel> location = new List<ATMLocationUIModel>();

                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    Locations = new ObservableCollection<ATMLocationUIModel>(Alllocations);
                }
                else
                {
                    var lowerSearchText = SearchText.ToLower();

                    foreach (ATMLocationUIModel locationUIModel in Alllocations)
                    {
                        if (locationUIModel.Name.ToLower(). Contains(lowerSearchText))
                        {
                            location.Add(locationUIModel);
                        }
                        else if (locationUIModel.City != null &&locationUIModel.City.ToLower().Contains(lowerSearchText))
                        {
                            location.Add(locationUIModel);
                        }
                    }

                    Locations = new ObservableCollection<ATMLocationUIModel>(location);
                }
            }
        }

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
