using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using XoshBank.App.Repositories;
using XoshBankCore;
using XoshBankCore.Entites.Repositories;
using XoshBankCore.Entities;
using XoshBankCore.Entities.Repositories;

namespace XoshBank.Persistent.SQLServer.Repositories
{
    public class  MsSQLUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;

        public MsSQLUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IBranchRepository Branches => new MsSQLBranchRepository(_connectionString);
        public ILoanRepository Loans => new MsSQLLoanRepository(_connectionString);
        public IAccountRepository Accounts => new MsSQLAccountRepository(_connectionString);
        public ICustomerRepository Customers => new MsSQLCustomerRepository(_connectionString);
        public ICardRepository Card => new MsSqlCardRepository(_connectionString);
        public IEmployeeRepository Employee => new MsSqlEmployeeRepository(_connectionString);

        public IATMLocationRepository ATMLocations => new MsSQLATMLocationRepository(_connectionString);

        public IPaymentTemplateRepository PaymentTemplates =>  new MsSQLPaymentTemplateRepository(_connectionString);
    }
}
    


