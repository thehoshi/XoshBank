using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Entities.Interfaces;


namespace XoshBankCore
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