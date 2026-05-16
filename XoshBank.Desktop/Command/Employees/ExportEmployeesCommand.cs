using Microsoft.Win32; 
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

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _viewModel.Employees.Count > 0;

        public void Execute(object parameter)
        {
            
            var dialog = new SaveFileDialog
            {
                Title = "Export Employees",
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                FileName = "employees.csv"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    using (var writer = new StreamWriter(dialog.FileName))
                    {
                        // Header
                        writer.WriteLine("ID,FirstName,LastName,Email,Phone,Position,Salary,HireDate,IsActive,CreatedDate,DeletedAt");

                        // Rows
                        foreach (var e in _viewModel.Employees)
                        {
                            writer.WriteLine($"{e.EmployeeId},{e.FirstName},{e.LastName},{e.Email},{e.Phone},{e.Position},{e.Salary},{e.HireDate},{e.IsActive},{e.DeletedAt}");
                        }
                    }

                    MessageBox.Show("Employees exported successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting employees: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
