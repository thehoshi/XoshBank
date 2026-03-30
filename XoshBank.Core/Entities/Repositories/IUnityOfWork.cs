using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBankCore.Entities.Repositories;

namespace SQLConnection.Entities.Repositories
{
    internal interface IUnityOfWork
    {
        IBrachesRepository Branches { get; }
        ILoansRepository Loans { get; }
    }
}
