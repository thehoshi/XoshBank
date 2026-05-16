using System;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
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

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _viewModel.CurrentState = Enums.ViewState.Add;
            _viewModel.CurrentCard = new CardFormModel();
        }
    }
}
