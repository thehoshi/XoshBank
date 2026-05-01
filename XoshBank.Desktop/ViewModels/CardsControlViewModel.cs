using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        }

        #region properties

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
                        CardId = SelectedCard.CardId,
                        CardNumber = SelectedCard.CardNumber,
                        ExpiryDate = SelectedCard.ExpiryDate,
                        CVV = SelectedCard.CVV,
                        CardType = SelectedCard.CardType,
                        Balance = SelectedCard.Balance,
                        AccountId = SelectedCard.AccountId,
                        IsActive = SelectedCard.IsActive,
                        CreatedDate = SelectedCard.CreatedDate,
                        DeletedAt = SelectedCard.DeletedAt
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

                var filtered = new List<CardUIModel>();

                if (string.IsNullOrWhiteSpace(SearchValue))
                {
                    Cards = new ObservableCollection<CardUIModel>(AllCards);
                }
                else
                {
                    var upper = SearchValue.ToUpper();

                    foreach (CardUIModel c in AllCards)
                    {
                        if (c.CardNumber?.ToUpper().Contains(upper) == true ||
                            c.CardType?.ToUpper().Contains(upper) == true)
                        {
                            filtered.Add(c);
                        }
                    }
                    Cards = new ObservableCollection<CardUIModel>(filtered);
                }
            }
        }

        #endregion

        #region commands

        public AddCardsCommand AddCommand => new AddCardsCommand(this);
        public SaveCardsCommand SaveCommand => new SaveCardsCommand(this);
        public EditCardsCommand EditCommand => new EditCardsCommand(this);
        public RejectCardsCommand RejectCommand => new RejectCardsCommand(this);
        public DeleteCardsCommand DeleteCommand => new DeleteCardsCommand(this);
        public ExportCardsCommand ExportCommand => new ExportCardsCommand(this);

        #endregion

        #region property changed

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
