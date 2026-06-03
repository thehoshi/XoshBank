using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Attributes;

namespace XoshBank.Models
{
    public class CustomerUIModel
    {
        public int No { get; set; }
        [ExcelColumnIgnore]
        public int ID { get; set; }
        [ExcelColumnStyle("First Name")]
        public string FirstName { get; set; }
        [ExcelColumnStyle("First Name")]

        [ExcelColumnStyle("Last Name")]
        public string LastName { get; set; }
        [ExcelColumnStyle("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [ExcelColumnStyle("Phone")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } = string.Empty;
        [ExcelColumnStyle("FIN")]
        public string FINCode { get; set; }
    }
}
