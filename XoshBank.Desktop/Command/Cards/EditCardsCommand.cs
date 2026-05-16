using System;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Cards
{
    public class EditCardsCommand : ICommand
    {
        private readonly CardsControlViewModel _viewModel;

        public EditCardsCommand(CardsControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _viewModel.SelectedCard != null;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedCard == null) return;

            
            _viewModel.CurrentState = ViewState.Edit;

            
            _viewModel.CurrentCard = new CardFormModel
            {
                CardId = _viewModel.SelectedCard.CardId,
                CardNumber = _viewModel.SelectedCard.CardNumber,
                ExpiryDate = _viewModel.SelectedCard.ExpiryDate,
                CVV = _viewModel.SelectedCard.CVV,
                CardType = _viewModel.SelectedCard.CardType,
                Balance = _viewModel.SelectedCard.Balance,
                AccountId = _viewModel.SelectedCard.AccountId,
                IsActive = _viewModel.SelectedCard.IsActive,
                CreatedDate = _viewModel.SelectedCard.CreatedDate,
                DeletedAt = _viewModel.SelectedCard.DeletedAt
            };
        }
    }
}

