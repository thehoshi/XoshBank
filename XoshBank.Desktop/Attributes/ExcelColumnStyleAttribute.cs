using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBank.Attributes
{
    public class ExcelColumnStyleAttribute : Attribute
    {
        public ExcelColumnStyleAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}

