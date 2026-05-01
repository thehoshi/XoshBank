using XoshBank.Core.Repositories;

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
        public ICardRepository Cards => new MsSQLCardRepository(_connectionString);
        public IEmployeeRepository Employees => new MsSqlEmployeeRepository(_connectionString);

        public IATMLocationRepository ATMLocations => new MsSQLATMLocationRepository(_connectionString);

        public IPaymentTemplateRepository PaymentTemplates =>  new MsSQLPaymentTemplateRepository(_connectionString);
    }
}
    


