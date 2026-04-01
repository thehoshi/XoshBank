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
        IBranchRepository Branches { get; }
        ILoanRepository Loans { get; }
        IAccountRepository Accounts { get; }
        ICustomerRepository Customers { get; }
        ICardRepository Card { get; }
        IEmployeeRepository Employee { get; }

    }
}
