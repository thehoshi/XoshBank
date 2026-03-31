using XoshBank.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBankCore
{
    public class Branches : IDeletable
    {
        public int ID { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int? EmployeeCount { get; set; }
        public DateTime? OpeningDate { get; set; }
        public double? Revenue { get; set; }
        public double? Expenses { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}