using XoshBankCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private IBranchesRepository _branchesRepository;


    }
}
