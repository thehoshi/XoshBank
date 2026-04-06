using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Command;

namespace XoshBank.ViewModels
{
    public class MainPageViewModel
    {
        public OpenAccountsCommand OpenAccounts => new OpenAccountsCommand();
        public OpenCustomersCommand OpenCustomers => new OpenCustomersCommand();
    }
}
