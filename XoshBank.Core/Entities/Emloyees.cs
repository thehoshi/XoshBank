using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Entities.Interfaces;

namespace XoshBankCore
{
    public class Employee : IDeletableDbEntity
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
