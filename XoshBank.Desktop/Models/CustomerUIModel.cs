using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBank.Models
{
    public class CustomerUIModel
    {
        public int ID { get; set; }
        public int No { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } = string.Empty;
        public string FINCode { get; set; }
    }
}
