using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;

namespace XoshBank.Command.Employees
{
    public class ExportEmployeesCommand : ICommand
    {
        private readonly EmployeesControlViewModel _viewModel;

        public ExportEmployeesCommand(EmployeesControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => _viewModel.Employees?.Count > 0;

        public void Execute(object parameter)
        {
            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"Employees_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv");

                using (var writer = new StreamWriter(path))
                {
               
                    writer.WriteLine("EmployeeId,FirstName,LastName,Email,Phone,Position,Salary,HireDate,IsActive,CreatedAt,DeletedAt");

                   
                    foreach (var e in _viewModel.Employees)
                    {
                        writer.WriteLine($"{e.EmployeeId}," +
                                         $"{e.FirstName}," +
                                         $"{e.LastName}," +
                                         $"{e.Email}," +
                                         $"{e.Phone}," +
                                         $"{e.Position}," +
                                         $"{e.Salary}," +
                                         $"{e.HireDate:dd.MM.yyyy}," +
                                         $"{e.IsActive}," +
                                         $"{e.DeletedAt:dd.MM.yyyy}");
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
