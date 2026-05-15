using System;
using XoshBank.Core.Entities.Interfaces;

namespace XoshBank.Core.Entities
{
    public class Employee : IDeletableDbEntity
    {
      
        public int ID
        {
            get => EmployeeId;
            set => EmployeeId = value;
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
