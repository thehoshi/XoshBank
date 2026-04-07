using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XoshBank.ViewModels;
using XoshBank.Views.UserControl;

namespace XoshBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainPageViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Loans_Click(object sender, RoutedEventArgs e)
        {
            var grid = ImageGrid;
            grid.Children.Clear();
            grid.Children.Add(new LoansControl());
        }

        private void Branches_Click(object sender, RoutedEventArgs e)
        {
            var grid = ImageGrid;
            grid.Children.Clear();
            grid.Children.Add(new BranchesControl());
        }
    }
}
