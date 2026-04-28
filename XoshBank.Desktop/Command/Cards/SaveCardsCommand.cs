using System;
using System.Windows;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Cards
{
    public class SaveCardsCommand : ICommand
    {
        private readonly CardsControlViewModel _viewModel;

        public SaveCardsCommand(CardsControlViewModel viewModel)
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
            var result = MessageBox.Show("Are you sure you want to save this card?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;

            var source = _viewModel.CurrentCard ?? new CardFormModel();

            var card = new Card
            {
                CardNumber = source.CardNumber,
                CardType = source.CardType,
                ExpiryDate = source.ExpiryDate,
                CVV = source.CVV,
                Balance = source.Balance,
                AccountId = source.AccountId,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            var isEdit = _viewModel.SelectedCard != null && _viewModel.SelectedCard.CardId > 0;
            if (isEdit)
            {
                card.CardId = _viewModel.SelectedCard.CardId;
                _viewModel.DB.Cards.Update(card);

                int index = _viewModel.Cards.IndexOf(_viewModel.SelectedCard);
                var updated = new CardUIModel
                {
                    CardId = card.CardId,
                    CardNumber = card.CardNumber,
                    CardType = card.CardType,
                    ExpiryDate = card.ExpiryDate,
                    CVV = card.CVV,
                    Balance = card.Balance,
                    AccountId = card.AccountId,
                    IsActive = card.IsActive?? false,
                    CreatedDate = card.CreatedDate,
                    DeletedAt = card.DeletedAt
                };
                if (index >= 0)
                {
                    _viewModel.AllCards[index] = updated;
                    _viewModel.Cards[index] = updated;
                }
                MessageBox.Show("Card updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _viewModel.DB.Cards.Insert(card);
                var newModel = new CardUIModel
                {
                    CardId = card.CardId,
                    CardNumber = card.CardNumber,
                    CardType = card.CardType,
                    ExpiryDate = card.ExpiryDate,
                    CVV = card.CVV,
                    Balance = card.Balance,
                    AccountId = card.AccountId,
                    IsActive = card.IsActive?? false,
                    CreatedDate = card.CreatedDate,
                    DeletedAt = card.DeletedAt
                };
                _viewModel.AllCards.Add(newModel);
                _viewModel.Cards.Add(newModel);
                MessageBox.Show("Card added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            _viewModel.SelectedCard = null;
            _viewModel.CurrentCard = new CardFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}
