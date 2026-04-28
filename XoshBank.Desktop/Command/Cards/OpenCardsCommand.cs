using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;
using XoshBank.Desktop.ViewModels;
using XoshBank.Desktop.Views.UserControls;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.Views.UserControls;

namespace XoshBank.Command.Cards
{
    public class OpenCardsCommand : ICommand
    {
        private readonly IUnitOfWork _db;

        public OpenCardsCommand(IUnitOfWork db)
        {
            _db = db;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            
            CardsControl cardsControl = new CardsControl();

            
            CardsControlViewModel viewModel = new CardsControlViewModel(_db);

            
            List<Card> cards = _db.Cards.GetAll();

            List<CardUIModel> cardUIModels = new List<CardUIModel>();

            foreach (Card card in cards)
            {
                CardUIModel cardUIModel = new CardUIModel
                {
                    CardId = card.CardId,
                    CardNumber = card.CardNumber,
                    CardType = card.CardType,
                    ExpiryDate = card.ExpiryDate,
                    CVV = card.CVV,
                    Balance = card.Balance,
                    AccountId = card.AccountId,
                    IsActive = card.IsActive ?? false,
                    CreatedDate = card.CreatedDate,
                    DeletedAt = card.DeletedAt
                };
                cardUIModels.Add(cardUIModel);
            }

           
            viewModel.AllCards = cardUIModels;
            viewModel.Cards = new ObservableCollection<CardUIModel>(cardUIModels);

            viewModel.CurrentCard = new CardFormModel();
            viewModel.CurrentState = ViewState.Default;

            cardsControl.DataContext = viewModel;

            
            Grid grid = (Grid)parameter;
            grid.Children.Clear();
            grid.Children.Add(cardsControl);
        }
    }
}
