using System;

namespace XoshBank.Models
{
    public class PaymentTemplateFormModel
    {
        public int No {  get; set; }
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string ServiceName { get; set; }
        public string CustomerCode {  get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public int CardId { get; set; }

    }
}
