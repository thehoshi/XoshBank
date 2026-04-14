using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBank.Models
{
    public class CardFormModel
    {
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string CardType { get; set; }
        public decimal? Balance { get; set; }
        public int AccountId { get; set; }
    }
}
