using System;
using System.Windows.Controls;

namespace XoshBank.Desktop.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CustomersControl.xaml
    /// </summary>
    public partial class CustomersControl : System.Windows.Controls.UserControl
    {
        public CustomersControl()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
