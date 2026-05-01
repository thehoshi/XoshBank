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
            _viewModel.CurrentState = ViewState.Add;

           
            int nextId = _viewModel.DB.Cards.GetNextId();
            _viewModel.CurrentCard.CardId = nextId;

           
            _viewModel.CurrentCard.CreatedDate = DateTime.Now;
            _viewModel.CurrentCard.IsActive = true;
        }
    }
}
