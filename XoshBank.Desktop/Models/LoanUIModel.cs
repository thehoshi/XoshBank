using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBank.Models
{
    public class LoanUIModel
    {
        public int No { get; set; }
        public int CustomerID { get; set; }
        public int ApprovedBy { get; set; }
        public int? BranchID { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public double TotalAmount { get; set; }
        public double MonthlyPayment { get; set; }
        public string Status { get; set; }
        public string LoanType { get; set; }
        public string Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public int DurationMonths { get; set; }
        public double? LatePaymentFee { get; set; }
        public double? PenaltyRate { get; set; }
        public string Collateral { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
