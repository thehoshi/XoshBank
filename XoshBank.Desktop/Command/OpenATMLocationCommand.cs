using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;
using XoshBank.Models;
using XoshBank.ViewModels;
using XoshBank.Views.UserControls;

namespace XoshBank.Desktop.Commands.MainPage
{
    public class OpenATMLocationCommand : ICommand
    {
        private readonly IUnitOfWork _db;
        public OpenATMLocationCommand(IUnitOfWork db)
        {
            _db= db;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ATMLocationControl control = new ATMLocationControl();

            ATMLocationsControlViewModel viewModel = new ATMLocationsControlViewModel();

            List<ATMLocation> Locations =  _db.ATMLocations.GetAll();
            
            List<ATMLocationUIModel> ATMLocationUIModels = new List<ATMLocationUIModel>();

            foreach (var Location in Locations)
            {
                ATMLocationUIModel atmocationUIModels = new ATMLocationUIModel 
                {
                    Name = Location.Name,
                    City = Location.City,
                    Address = Location.Address,
                    IsActive = Location.IsActive,
                };
                ATMLocationUIModels.Add(atmocationUIModels);
            }

            viewModel.Locations = ATMLocationUIModels;

            control.DataContext = viewModel;

            Grid grid =(Grid)parameter;

            grid.Children.Clear();

            grid.Children.Add(control);
        }
    }
}
