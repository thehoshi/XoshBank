using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBank.Models
{
    public class AccountUIModel
    {
        public int No { get; set; }
        public int CustomerID { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; } = string.Empty;
        public string Currency { get; set; }
    }
}
