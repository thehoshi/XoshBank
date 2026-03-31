using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBank.Entities.Interfaces
{
    public interface IDeletable : IDbEntities
    {
        DateTime? DeletedAt { get; set; }
    }
}
