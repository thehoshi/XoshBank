using System.Windows.Controls;
using XoshBank.Core.Repositories;
using XoshBank.Desktop.ViewModels;

namespace XoshBank.Desktop.Views.UserControls
{
    public partial class EmployeesControl : UserControl
    {
        public EmployeesControl(IUnitOfWork db)
        {
            InitializeComponent();
            DataContext = new EmployeesControlViewModel(db);
        }

     
        public EmployeesControl()
        {
            InitializeComponent();
        }
    }
}
