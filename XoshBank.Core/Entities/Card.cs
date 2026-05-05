using System;
using XoshBank.Core.Entities.Interfaces;

namespace XoshBank.Core.Entities
{
    public class Card : IDeletableDbEntity
    {
        public int ID { get; set; }
        public int CardId { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public decimal? Balance { get; set; }
        public int AccountId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

