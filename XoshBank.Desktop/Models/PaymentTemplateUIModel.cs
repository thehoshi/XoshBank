using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBank.Models
{
    public class PaymentTemplateUIModel
    {
        public int No {  get; set; }
        public int ID { get; set; }
        public string TemplateName { get; set; }
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; } 

        public string CustomerCode {  get; set; }
    }
}
