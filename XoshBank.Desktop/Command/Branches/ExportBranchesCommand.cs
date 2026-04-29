using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;

namespace XoshBank.Command.Branches
{
    public class ExportBranchesCommand : ICommand
    {
        private readonly BranchesControlViewModel _viewModel;
        public ExportBranchesCommand(BranchesControlViewModel viewModel)
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
                    $"Branches_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv");

                using (var writer = new StreamWriter(path))
                {
                
                    writer.WriteLine("ID,Branch Name,City,Address,Manager,Phone,Employees,Opening Date,Revenue,Expenses");

                   
                    foreach (var b in _viewModel.Branches)
                    {
                        writer.WriteLine($"{b.ID}," +
                                         $"{b.BranchName}," +
                                         $"{b.City}," +
                                         $"{b.Address}," +
                                         $"{b.ManagerName}," +
                                         $"{b.PhoneNumber}," +
                                         $"{b.EmployeeCount}," +
                                         $"{b.OpeningDate:dd.MM.yyyy}," +
                                         $"{b.Revenue}," +
                                         $"{b.Expenses}");
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