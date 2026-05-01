using System.Windows.Controls;
using XoshBank.Desktop.ViewModels;
using XoshBank.Core.Repositories;

namespace XoshBank.Desktop.Views.UserControls
{
    public partial class CardsControl : UserControl
    {
        
        public CardsControl()
        {
            InitializeComponent();
        }

        public CardsControl(IUnitOfWork db) : this()
        {
            DataContext = new CardsControlViewModel(db);
        }
    }
}
