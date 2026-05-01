using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.Core.Entities;

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
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (_viewModel.CurrentCard == null) return;

            try
            {
           
                var entity = new Card
                {
                    CardId = _viewModel.CurrentCard.CardId,
                    CardNumber = _viewModel.CurrentCard.CardNumber,
                    ExpiryDate = _viewModel.CurrentCard.ExpiryDate,
                    CVV = _viewModel.CurrentCard.CVV,
                    CardType = _viewModel.CurrentCard.CardType,
                    Balance = _viewModel.CurrentCard.Balance,
                    AccountId = _viewModel.CurrentCard.AccountId,
                    IsActive = _viewModel.CurrentCard.IsActive,
                    CreatedDate = _viewModel.CurrentCard.CreatedDate,
                    DeletedAt = _viewModel.CurrentCard.DeletedAt
                };

                if (_viewModel.CurrentState == ViewState.Add)
                {

                    _viewModel.DB.Cards.Insert(entity);

            
                    var uiModel = new CardUIModel
                    {
                        CardId = entity.CardId,
                        CardNumber = entity.CardNumber,
                        ExpiryDate = entity.ExpiryDate,
                        CVV = entity.CVV,
                        CardType = entity.CardType,
                        Balance = entity.Balance,
                        AccountId = entity.AccountId,
                        IsActive = entity.IsActive,
                        CreatedDate = entity.CreatedDate,
                        DeletedAt = entity.DeletedAt
                    };

                    _viewModel.AllCards.Add(uiModel);
                    _viewModel.Cards.Add(uiModel);

                    MessageBox.Show("Card added successfully!", "Success", MessageBoxButton.OK);
                }
                else if (_viewModel.CurrentState == ViewState.Edit)
                {
                    _viewModel.DB.Cards.Update(entity);

                    var existing = _viewModel.AllCards.FirstOrDefault(c => c.CardId == entity.CardId);
                    if (existing != null)
                    {
                        existing.CardNumber = entity.CardNumber;
                        existing.ExpiryDate = entity.ExpiryDate;
                        existing.CVV = entity.CVV;
                        existing.CardType = entity.CardType;
                        existing.Balance = entity.Balance;
                        existing.AccountId = entity.AccountId;
                        existing.IsActive = entity.IsActive;
                        existing.CreatedDate = entity.CreatedDate;
                        existing.DeletedAt = entity.DeletedAt;
                    }

                    MessageBox.Show("Card updated successfully!", "Success", MessageBoxButton.OK);
                }

                _viewModel.SelectedCard = null;
                _viewModel.CurrentCard = new CardFormModel();
                _viewModel.CurrentState = ViewState.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving card: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
