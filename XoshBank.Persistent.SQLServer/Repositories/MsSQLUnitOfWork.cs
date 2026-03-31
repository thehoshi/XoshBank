using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using XoshBankCore;
using XoshBankCore.Entities;
using XoshBankCore.Entities.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class MsSQLUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;

        public MsSQLUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BranchesRepository Branches => new MsSQLBranchesRepository(_connectionString);
        public LoansRepository Loans => new MsSQLLoansRepository(_connectionString);
        public AccountsRepository Accounts => new MsSQLAccountsRepository(_connectionString);
        public CustomersRepository Customers => new MsSQLCustomersRepository(_connectionString);

    }
}
