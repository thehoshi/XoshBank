using XoshBank.Core.Entities.Interfaces;

namespace XoshBank.Core.Entities
{
    public class ATMLocation : IDbEntity
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
