using System;
using System.Collections.Generic;
using System.Linq;
using XoshBankCore.Entities;
using XoshBankCore.Entities.Repositories;

namespace XoshBankCore.Repositories
{
    public class CardRepository : IBaseRepository<Card>
    {
        private readonly List<Card> _cards = new List<Card>();

        public void Add(Card card) => _cards.Add(card);

        public Card GetById(int id) => _cards.FirstOrDefault(c => c.ID == id);

        public void Update(Card card)
        {
            var existing = GetById(card.ID);
            if (existing != null)
            {
                existing.CardNumber = card.CardNumber;
                existing.ExpiryDate = card.ExpiryDate;
                existing.EmployeeId = card.EmployeeId;
            }
        }

        public void Delete(int id)
        {
            var card = GetById(id);
            if (card != null)
                _cards.Remove(card);
        }

        public List<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Card entity)
        {
            throw new NotImplementedException();
        }
    }
}