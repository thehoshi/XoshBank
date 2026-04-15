using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.App.Entities;
using XoshBank.Models;
using XoshBank.ViewModels;
using XoshBank.Views.UserControls;
using XoshBankCore.Entities.Repositories;

namespace XoshBank.Command
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
            List<ATMLocations> Locations =  _db.ATMLocations.GetAll();
            
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
            }
            ATMLocationControl control = new ATMLocationControl();

            ATMLocationsControlViewModel viewModel = new ATMLocationsControlViewModel(); 

            control.DataContext = viewModel;

            Grid grid =(Grid)parameter;

            grid.Children.Clear();

            grid.Children.Add(control);
        }
    }
}
