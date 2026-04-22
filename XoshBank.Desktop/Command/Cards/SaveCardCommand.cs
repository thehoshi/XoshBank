
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.ViewModels;


namespace XoshBank.Command.Cards
{
    public class SaveCardCommand
    {
        private readonly CardsControlViewModel _viewModel;
        public SaveCardCommand(CardsControlViewModel viewModel)
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
            _viewModel.CurrentState = ViewState.Save;
        }
    }
}
