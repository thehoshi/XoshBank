using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Entities;
using XoshBankCore;
using XoshBankCore.Entities.Repositories;

namespace XoshBankCore.Entities.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {

    }
}