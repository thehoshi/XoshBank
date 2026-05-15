using System;
using XoshBank.Attributes;

namespace XoshBank.Models
{
    public class BranchUIModel
    {
        [ExcelColumnStyle("ID")]
        public int ID { get; set; }

        [ExcelColumnStyle("Branch Name")]
        public string BranchName { get; set; }

        [ExcelColumnStyle("City")]
        public string City { get; set; }

        [ExcelColumnStyle("Address")]
        public string Address { get; set; }

        [ExcelColumnStyle("Manager")]
        public string ManagerName { get; set; }

        [ExcelColumnStyle("Phone")]
        public string PhoneNumber { get; set; }

        [ExcelColumnStyle("Employees")]
        public int? EmployeeCount { get; set; }

        [ExcelColumnStyle("Opening Date")]
        public DateTime? OpeningDate { get; set; }

        [ExcelColumnStyle("Revenue")]
        public double? Revenue { get; set; }

        [ExcelColumnStyle("Expenses")]
        public double? Expenses { get; set; }

        [ExcelColumnIgnore]
        public DateTime? DeletedAt { get; set; }
    }
}