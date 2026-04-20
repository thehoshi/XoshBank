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
using System.Windows;

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
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to save it?", "Question", MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (messageBoxResult != MessageBoxResult.Yes)
                return;

                ATMLocation Location = new ATMLocation
                {
                    ID = viewModel.CurrentATMLocation.Id,
                    Name = viewModel.CurrentATMLocation.Name,
                    City = viewModel.CurrentATMLocation.City,
                    Address = viewModel.CurrentATMLocation.Address,
                    IsActive = viewModel.CurrentATMLocation.IsActive,
                };
            
            if(ATMLocation.Id > 0)
            {
                viewModel.DB.ATMLocations.Update(Location);

                ATMLocationUIModel locationUIModel = new ATMLocationUIModel
                {   No = viewModel.SelectedLocation.No, 
                    ID = Location.ID,
                    Name = Location.Name,
                    City = Location.City,
                    Address = Location.Address,
                    IsActive = Location.IsActive,
                };
                int selectedATMIndex = viewModel.SelectedLocation.No - 1;
                viewModel.Locations[selectedATMIndex] = locationUIModel;
            }
            else
            {
                viewModel.DB.ATMLocations.Add(Location);
                ATMLocationUIModel locationUIModel = new ATMLocationUIModel
                {
                    No = viewModel.Locations.Count + 1,
                    ID = Location.ID,
                    Name = Location.Name,
                    City = Location.City,
                    Address = Location.Address,
                    IsActive = Location.IsActive,
                };

            }


            //mapping from UI model to entity
            ATMLocationUIModel LocationUIModel = new ATMLocationUIModel
            {
                ID = Location.ID,
                Name = Location.Name,
                City = Location.City,
                Address = Location.Address,
                IsActive = Location.IsActive,
            };


            viewModel.Locations.Add(LocationUIModel);

            viewModel.CurrentState = ViewState.Default;
            viewModel.CurrentATMLocation = new ATMLocationFormModel();

            MessageBox.Show("ATM saved successfully!", "Succsess", MessageBoxButton.OK);
        }
    }
}
