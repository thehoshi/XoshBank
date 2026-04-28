using XoshBank.Command;
using XoshBank.Command.Branches;
using XoshBank.Command.Loans;
using XoshBank.Core.Repositories;
using XoshBank.Command.Accounts;
using XoshBank.Command.Customers;
using XoshBank.Command.Cards;

namespace XoshBank.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainPageViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OpenAccountsCommand OpenAccounts => new OpenAccountsCommand(_unitOfWork);
        public OpenCustomersCommand OpenCustomers => new OpenCustomersCommand(_unitOfWork);
        public OpenLoansCommand OpenLoans => new OpenLoansCommand();
        public OpenBranchesCommand OpenBranches => new OpenBranchesCommand(_unitOfWork);
        public OpenCardsCommand OpenCards => new OpenCardsCommand(_unitOfWork);
        public OpenEmployeeCommand OpenEmployee => new OpenEmployeeCommand();
        public OpenATMLocationCommand OpenATMLocation => new OpenATMLocationCommand(_unitOfWork);
        public OpenPaymentTemplateCommand OpenPaymentTemplate => new OpenPaymentTemplateCommand(_unitOfWork);
    }
}
