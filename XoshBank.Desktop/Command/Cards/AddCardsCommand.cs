using System;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Cards
{
    public class AddCardsCommand : ICommand
    {
        private readonly CardsControlViewModel _viewModel;

        public AddCardsCommand(CardsControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _viewModel.SelectedCard = null;
            _viewModel.CurrentCard = new CardFormModel();
            _viewModel.CurrentState = ViewState.Add;
        }
    }
}
