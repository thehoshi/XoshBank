using System.Collections.Generic;

namespace XoshBank.Web.Models
{
    public class BranchUiModel
    {
        public List<BranchModel> Branches { get; set; } = new List<BranchModel>();
    }

    public class BranchModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string BranchName { get; set; } = "";
        public string City { get; set; } = "";
        public string Address { get; set; } = "";
        public string ManagerName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public int? EmployeeCount { get; set; }
        public DateTime? OpeningDate { get; set; }
        public double? Revenue { get; set; }
        public double? Expenses { get; set; }
    }
}