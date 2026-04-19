using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.ViewModels;

namespace XoshBank.Command.ATMLocations
{
    public class AddATMLocationCommand : ICommand
    {
        private readonly ATMLocationsControlViewModel _viewModel;
        public AddATMLocationCommand(ATMLocationsControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.CurrentState = 2;
        }
    }
}
