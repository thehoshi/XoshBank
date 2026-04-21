using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBank.Models
{
    public class BranchUIModel
    {
        public int No {  get; set; }
        public string AccountNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ManagerName { get; set; }
        public string PhoneNUmber { get; set; }
        public int? EmployeeCount { get; set; }
        public DateTime? OpeningDate { get; set; }
        public double? Revenue { get; set; }
        public double? Expenses { get; set; }
    }
}
