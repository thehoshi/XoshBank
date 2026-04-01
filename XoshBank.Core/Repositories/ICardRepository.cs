using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Entities;
using XoshBankCore.Entities.Repositories;

namespace XoshBankCore.Entities.Repositories
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        List<Card> GetCardsByAccountId(int accountId);
    }
}
