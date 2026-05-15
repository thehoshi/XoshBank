using System;
using XoshBank.Attributes;

namespace XoshBank.Models
{
    public class LoanUIModel
    {
        [ExcelColumnStyle("No")]
        public int No { get; set; }

        [ExcelColumnStyle("Customer ID")]
        public int CustomerID { get; set; }

        [ExcelColumnStyle("Approved By")]
        public int ApprovedBy { get; set; }

        [ExcelColumnStyle("Branch ID")]
        public int? BranchID { get; set; }

        [ExcelColumnStyle("Amount")]
        public double Amount { get; set; }

        [ExcelColumnStyle("Interest Rate")]
        public double InterestRate { get; set; }

        [ExcelColumnStyle("Total Amount")]
        public double TotalAmount { get; set; }

        [ExcelColumnStyle("Monthly Payment")]
        public double MonthlyPayment { get; set; }

        [ExcelColumnStyle("Status")]
        public string Status { get; set; }

        [ExcelColumnStyle("Loan Type")]
        public string LoanType { get; set; }

        [ExcelColumnStyle("Currency")]
        public string Currency { get; set; }

        [ExcelColumnStyle("Start Date")]
        public DateTime StartDate { get; set; }

        [ExcelColumnStyle("End Date")]
        public DateTime EndDate { get; set; }

        [ExcelColumnStyle("Approval Date")]
        public DateTime ApprovalDate { get; set; }

        [ExcelColumnStyle("Duration (Months)")]
        public int DurationMonths { get; set; }

        [ExcelColumnStyle("Late Payment Fee")]
        public double? LatePaymentFee { get; set; }

        [ExcelColumnStyle("Penalty Rate")]
        public double? PenaltyRate { get; set; }

        [ExcelColumnStyle("Collateral")]
        public string Collateral { get; set; } = string.Empty;

        [ExcelColumnStyle("Notes")]
        public string Notes { get; set; } = string.Empty;
    }
}