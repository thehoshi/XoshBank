using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBankCore.Entities;

namespace XoshBankCore.Interfaces
{
    public interface ICardRepository
    {
        void Add(Card card);
        Card GetById(int id);
        IEnumerable<Card> GetAll();
        void Update(Card card);
        void Delete(int id);
    }
}