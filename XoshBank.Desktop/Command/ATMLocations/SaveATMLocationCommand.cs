using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.ViewModels;
using XoshBank.Core.Entities;
using XoshBank.Models;
using XoshBank.Enums;

namespace XoshBank.Command.ATMLocations
{
    public class SaveATMLocationCommand : ICommand
    {
        private readonly ATMLocationsControlViewModel viewModel;

        public SaveATMLocationCommand(ATMLocationsControlViewModel viewModel)
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
            ATMLocation Location = new ATMLocation
            {
                Name = viewModel.CurrentATMLocation.Name,
                City = viewModel.CurrentATMLocation.City,
                Address = viewModel.CurrentATMLocation.Address,
                IsActive = viewModel.CurrentATMLocation.IsActive,
            };

            viewModel.DB.ATMLocations.Add(Location);


            //mapping from UI model to entity
            ATMLocationUIModel LocationUIModel = new ATMLocationUIModel
            {
                Name = Location.Name,
                City = Location.City,
                Address = Location.Address,
                IsActive = Location.IsActive,
                ID = viewModel.Locations.Count + 1,
            };


            viewModel.Locations.Add(LocationUIModel);

            viewModel.CurrentState = ViewState.Default;
            viewModel.CurrentATMLocation = new ATMLocationFormModel();
        }
    }
}
