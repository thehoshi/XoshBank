using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.App.Entities.Interfaces;

namespace XoshBank.App.Entities
{
    public class ATMLocation : IDbEntity
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
