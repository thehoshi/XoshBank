using System;
using System.ComponentModel;

namespace XoshBank.Models
{
    public class CardFormModel : INotifyPropertyChanged
    {
        private int _cardId;
        private string _cardNumber;
        private DateTime _expiryDate;
        private string _cvv;
        private string _cardType;
        private decimal? _balance;
        private int _accountId;
        private bool _isActive;
        private DateTime? _createdDate;
        private DateTime? _deletedAt;

        public int CardId
        {
            get => _cardId;
            set { _cardId = value; OnPropertyChanged(nameof(CardId)); }
        }
        public string CardNumber
        {
            get => _cardNumber;
            set { _cardNumber = value; OnPropertyChanged(nameof(CardNumber)); }
        }
        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set { _expiryDate = value; OnPropertyChanged(nameof(ExpiryDate)); }
        }
        public string CVV
        {
            get => _cvv;
            set { _cvv = value; OnPropertyChanged(nameof(CVV)); }
        }
        public string CardType
        {
            get => _cardType;
            set { _cardType = value; OnPropertyChanged(nameof(CardType)); }
        }
        public decimal? Balance
        {
            get => _balance;
            set { _balance = value; OnPropertyChanged(nameof(Balance)); }
        }
        public int AccountId
        {
            get => _accountId;
            set { _accountId = value; OnPropertyChanged(nameof(AccountId)); }
        }
        public bool IsActive
        {
            get => _isActive;
            set { _isActive = value; OnPropertyChanged(nameof(IsActive)); }
        }
        public DateTime? CreatedDate
        {
            get => _createdDate;
            set { _createdDate = value; OnPropertyChanged(nameof(CreatedDate)); }
        }
        public DateTime? DeletedAt
        {
            get => _deletedAt;
            set { _deletedAt = value; OnPropertyChanged(nameof(DeletedAt)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
