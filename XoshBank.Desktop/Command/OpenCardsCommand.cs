using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Desktop.Views.UserControls;
using XoshBank.Views.UserControls;


namespace XoshBank.Command
{
    public class OpenCardsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CardsControl cardsControl = new CardsControl();

            Grid grid = (Grid)parameter;

            grid.Children.Clear();
            grid.Children.Add(cardsControl);
        }
    }
}
