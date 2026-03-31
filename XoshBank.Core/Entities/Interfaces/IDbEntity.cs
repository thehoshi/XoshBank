using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Entities.Interfaces;

namespace XoshBank.Entities.Interfaces
{
    public interface IDbEntity
    {
        int ID { get; set; }
    }
}

