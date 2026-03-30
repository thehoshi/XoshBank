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

        public IBranchesRepository Branches => new MsSQLBranchesRepository(_connectionString);
        public ILoansRepository Loans => new MsSQLLoansRepository(_connectionString);


    }
}
