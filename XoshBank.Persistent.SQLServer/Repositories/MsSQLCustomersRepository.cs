using System;
using System.Collections.Generic;
using XoshBank.Entities;
using XoshBankCore.Entities.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLCustomersRepository : CustomersRepository
    {
        private string connectionString;

        public MsSQLCustomersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customers> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customers GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customers entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customers entity)
        {
            throw new NotImplementedException();
        }
    }
}
