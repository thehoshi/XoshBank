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
using System.Windows.Shapes;

namespace XoshBank.Views.UserControls
{
    /// <summary>
    /// Interaction logic for BranchesControl.xaml
    /// </summary>
    public partial class CardsControl : System.Windows.Controls.UserControl
    {
        public CardsControl() => InitializeComponent();

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
