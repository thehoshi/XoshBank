using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Entities;

namespace XoshBank.Models
{
    public class PaymentTemplateFormModel
    {
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
