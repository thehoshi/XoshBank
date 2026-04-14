using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Command;
using XoshBank.Command.Branches;
using XoshBank.Command.Loans;

namespace XoshBank.ViewModels
{
    public class MainPageViewModel
    {
        public OpenAccountsCommand OpenAccounts => new OpenAccountsCommand();
        public OpenCustomersCommand OpenCustomers => new OpenCustomersCommand();
        public OpenLoansCommand OpenLoans => new OpenLoansCommand();
        public OpenBranchesCommand OpenBranches => new OpenBranchesCommand();
        public OpenCardsCommand OpenCards => new OpenCardsCommand();
        public OpenEmployeesCommand OpenEmployees => new OpenEmployeesCommand();
        public OpenATMLocationCommand OpenATMLocation => new OpenATMLocationCommand();
        public OpenPaymentTemplateCommand OpenPaymentTemplate => new OpenPaymentTemplateCommand();
    }
}
