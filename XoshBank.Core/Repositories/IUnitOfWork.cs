using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoshBank.Core.Repositories
{
    public interface IUnitOfWork
    {
        IBranchRepository Branches { get; }
        ILoanRepository Loans { get; }
        IAccountRepository Accounts { get; }
        ICustomerRepository Customers { get; }
        ICardRepository Card { get; }
        IEmployeeRepository Employee { get; }

        IATMLocationRepository ATMLocations { get; }
        IPaymentTemplateRepository PaymentTemplates { get; }

    }
}
