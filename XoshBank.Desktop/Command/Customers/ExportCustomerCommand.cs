using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.ViewModels;

namespace XoshBank.Command.Customers
{
    public class ExportCustomerCommand : ICommand
    {
        private readonly CustomersControlViewModel _viewModel;
        public ExportCustomerCommand(CustomersControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"Customers_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv");

                using (var writer = new StreamWriter(path))
                {

                    writer.WriteLine("ID,First Name,Last Name,Birthday,Phone Number,Address,FIN Code, Created At");


                    foreach (var b in _viewModel.Customers)
                    {
                        writer.WriteLine($"{b.ID};" +
                                         $"{b.FirstName};" +
                                         $"{b.LastName};" +
                                         $"{b.DateOfBirth:dd.MM.yyyy};" +
                                         $"{b.PhoneNumber};" +
                                         $"{b.Email};"+
                                         $"{b.Address};" +
                                         $"{b.FINCode};"+
                                         $"{b.CreatedAt};");
                                        
                                     
                    }
                }

                MessageBox.Show($"Exported successfully!\n\nSaved to:\n{Path.GetFullPath(path)}",
                    "Export", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
