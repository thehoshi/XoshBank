using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Core.Entities;

namespace XoshBank.Core.Repositories
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        List<Card> GetCardsByAccountId(int accountId);
    }
}
