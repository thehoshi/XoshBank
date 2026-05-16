using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;
using XoshBank.Command.Cards;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Desktop.ViewModels
{
    public class CardsControlViewModel : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _db;

        public CardsControlViewModel(IUnitOfWork db)
        {
            _db = db;

            
            CardTypes = new ObservableCollection<string> { "Debit", "Credit" };

            
            Accounts = new ObservableCollection<Account>(_db.Accounts.GetAll().ToList());

           
            AllCards = _db.Cards.GetAll().Select(c => new CardUIModel
            {
                CardId = c.CardId,
                CardNumber = c.CardNumber,
                ExpiryDate= c.ExpiryDate,
                CVV = c.CVV,
                CardType = c.CardType,
                Balance = c.Balance,
                AccountId = c.AccountId,
                IsActive = c.IsActive,
                CreatedDate = c.CreatedDate,
                DeletedAt = c.DeletedAt
            }).ToList();

            Cards = new ObservableCollection<CardUIModel>(AllCards);

            CurrentCard = new CardFormModel();
            CurrentState = ViewState.Default;
        }

        #region Properties

        public IUnitOfWork DB => _db;

        private ViewState _currentState;
        public ViewState CurrentState
        {
            get => _currentState;
            set { _currentState = value; OnPropertyChanged(nameof(CurrentState)); }
        }

        private CardFormModel _currentCard;
        public CardFormModel CurrentCard
        {
            get => _currentCard;
            set { _currentCard = value; OnPropertyChanged(nameof(CurrentCard)); }
        }

        private CardUIModel _selectedCard;
        public CardUIModel SelectedCard
        {
            get => _selectedCard;
            set
            {
                _selectedCard = value;
                OnPropertyChanged(nameof(SelectedCard));

                if (value != null)
                {
                    CurrentState = ViewState.Selected;
                    CurrentCard = new CardFormModel
                    {
                        CardId = value.CardId,
                        CardNumber = value.CardNumber,
                        ExpiryDate = value.ExpiryDate,
                        CVV = value.CVV,
                        CardType = value.CardType,
                        Balance = value.Balance,
                        AccountId = value.AccountId,
                        IsActive = value.IsActive,
                        CreatedDate = value.CreatedDate,
                        DeletedAt = value.DeletedAt
                    };
                }
                else
                {
                    CurrentState = ViewState.Default;
                    CurrentCard = new CardFormModel();
                }
            }
        }

        private ObservableCollection<CardUIModel> _cards;
        public ObservableCollection<CardUIModel> Cards
        {
            get => _cards;
            set { _cards = value; OnPropertyChanged(nameof(Cards)); }
        }

        public List<CardUIModel> AllCards { get; set; }

        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));

                if (string.IsNullOrWhiteSpace(SearchValue))
                {
                    Cards = new ObservableCollection<CardUIModel>(AllCards);
                }
                else
                {
                    var upper = SearchValue.ToUpper();
                    var filtered = AllCards.Where(c =>
                        (c.CardNumber?.ToUpper().Contains(upper) ?? false) ||
                        (c.CardType?.ToUpper().Contains(upper) ?? false)
                    ).ToList();

                    Cards = new ObservableCollection<CardUIModel>(filtered);
                }
            }
        }

       
        public ObservableCollection<string> CardTypes { get; set; }
        public ObservableCollection<Account> Accounts { get; set; }

        #endregion

        #region Commands

        public AddCardsCommand AddCommand => new AddCardsCommand(this);
        public SaveCardsCommand SaveCommand => new SaveCardsCommand(this);
        public EditCardsCommand EditCommand => new EditCardsCommand(this);
        public RejectCardsCommand RejectCommand => new RejectCardsCommand(this);
        public DeleteCardsCommand DeleteCommand => new DeleteCardsCommand(this);
        public ExportCardsCommand ExportCommand => new ExportCardsCommand(this);

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
