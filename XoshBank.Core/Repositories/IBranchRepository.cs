using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Core.Entities;

namespace XoshBank.Core.Repositories
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        int GetNextId();

    }
}
