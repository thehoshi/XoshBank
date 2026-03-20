using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnection.Tables
{
    public class Loans
    {
        public int LoadID { get; set; }
        public int CustomerID { get; set; }
        public string ApprovedBy { get; set; }
        public int BrunchID { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
    }
    
}
