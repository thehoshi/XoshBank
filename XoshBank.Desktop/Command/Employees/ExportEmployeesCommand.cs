using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using XoshBank.Models;
using XoshBank.Desktop.ViewModels;

namespace XoshBank.Command.Employees
{
    public class ExportEmployeesCommand : ICommand
    {
        private readonly EmployeesControlViewModel viewModel;

        public ExportEmployeesCommand(EmployeesControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx"
            };

            if (saveFileDialog.ShowDialog() != true)
                return;

            string fileName = saveFileDialog.FileName;

            var table = new DataTable("Employees");
            table.Columns.Add("EmployeeId");
            table.Columns.Add("FirstName");
            table.Columns.Add("LastName");
            table.Columns.Add("Email");
            table.Columns.Add("Phone");
            table.Columns.Add("Position");
            table.Columns.Add("Salary");
            table.Columns.Add("HireDate");
            table.Columns.Add("IsActive");
            table.Columns.Add("DeletedAt");

            foreach (var emp in viewModel.Employees)
            {
                table.Rows.Add(emp.EmployeeId, emp.FirstName, emp.LastName, emp.Email,
                               emp.Phone, emp.Position, emp.Salary, emp.HireDate,
                               emp.IsActive, emp.DeletedAt);
            }

            using (XLWorkbook workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(table);
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(fileName);
            }

            if (MessageBox.Show("File is ready. Do you want to open it?", "Question",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Process.Start(fileName);
            }
        }
    }
}
