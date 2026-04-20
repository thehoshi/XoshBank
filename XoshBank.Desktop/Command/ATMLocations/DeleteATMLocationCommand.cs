using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XoshBank.Models;
using XoshBank.ViewModels;

namespace XoshBank.Command.ATMLocations
{
    public class DeleteATMLocationCommand : ICommand
    {
        private readonly ATMLocationsControlViewModel viewModel;

        public DeleteATMLocationCommand(ATMLocationsControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to delete it?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult != MessageBoxResult.Yes)
                return;

            int id = viewModel.SelectedLocation.ID;

            viewModel.DB.ATMLocations.Delete(id);

            int selectedATMIndex = viewModel.SelectedLocation.No - 1;

            viewModel.Locations.RemoveAt(selectedATMIndex);

            for(int i = selectedATMIndex; i < viewModel.Locations.Count; i++)
            {
                ATMLocationUIModel iteration = viewModel.Locations[i];

                viewModel.Locations[i] = new ATMLocationUIModel
                {
                    No = i + 1,
                    ID = iteration.ID,
                    Name = iteration.Name,

                };
            }

            MessageBox.Show("ATM deleted successfully!", "Succsess", MessageBoxButton.OK);

        }
    }
}
