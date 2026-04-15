using System;
using XoshBank.Core.Entities.Interfaces;

namespace XoshBank.Core.Entities
{
    public class Account : IDeletableDbEntity
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; } = string.Empty;
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}