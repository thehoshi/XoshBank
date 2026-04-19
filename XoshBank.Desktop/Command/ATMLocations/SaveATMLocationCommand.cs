using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.ViewModels;

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
            throw new NotImplementedException();
        }
    }
}
