using XoshBank.Command;
using XoshBank.Command.Branches;
using XoshBank.Command.Loans;
using XoshBank.Core.Repositories;

namespace XoshBank.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainPageViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OpenAccountsCommand OpenAccounts => new OpenAccountsCommand();
        public OpenCustomersCommand OpenCustomers => new OpenCustomersCommand();
        public OpenLoansCommand OpenLoans => new OpenLoansCommand(_unitOfWork);
        public OpenBranchesCommand OpenBranches => new OpenBranchesCommand(_unitOfWork);
        public OpenCardsCommand OpenCards => new OpenCardsCommand();
        public OpenEmployeesCommand OpenEmployees => new OpenEmployeesCommand();
        public OpenATMLocationCommand OpenATMLocation => new OpenATMLocationCommand(_unitOfWork);
        public OpenPaymentTemplateCommand OpenPaymentTemplate => new OpenPaymentTemplateCommand(_unitOfWork);
    }
}
