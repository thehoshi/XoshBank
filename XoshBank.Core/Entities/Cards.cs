using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Entities.Interfaces;

namespace XoshBankCore.Entities
{
    public class Card : IDeletable
    {
        public int ID { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public int EmployeeId { get; set; }
        public decimal Balance { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}