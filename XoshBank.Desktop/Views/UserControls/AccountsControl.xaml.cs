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

namespace XoshBank.Desktop.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AccountsControl.xaml
    /// </summary>
    public partial class AccountsControl : System.Windows.Controls.UserControl
    {
        public AccountsControl() => InitializeComponent();

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
