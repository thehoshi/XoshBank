using System;
using XoshBank.Entities;
using XoshBank.Entities.Interfaces;

namespace XoshBank.App.Entities
{
    public class PaymentTemplate : IDbEntity
    {
        public int ID {  get; set; }
        public string TemplateName { get; set; }
        public string ServiceName { get; set; }
        public string CustomerCode { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int CardId { get; set; }
        public Card card { get; set; }
    }
}
