using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBankCore.Entities.Repositories;

namespace XoshBankCore.Entities.Repositories
{
    public interface IUnitOfWork
    {
        IBranchesRepository Branches { get; }
        ILoansRepository Loans { get; }
    }
}
