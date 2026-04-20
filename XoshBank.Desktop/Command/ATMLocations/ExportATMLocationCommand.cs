using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.ViewModels;

namespace XoshBank.Command.ATMLocations
{
    public class ExportATMLocationCommand : ICommand
    {
        private readonly ATMLocationsControlViewModel viewModel;

        public ExportATMLocationCommand(ATMLocationsControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";


            bool? dialogueResult = saveFileDialog.ShowDialog();

            if (dialogueResult != true)
                return;

            string fileName = saveFileDialog.FileName;

            var table = new DataTable("ATMLocations");

            table.Columns.Add("No");
            table.Columns.Add("Name");
            table.Columns.Add("City");
            table.Columns.Add("Address");
            table.Columns.Add("IsActive");

            foreach (var atm in viewModel.Locations)
            {
                table.Rows.Add(atm.No, atm.Name, atm.City, atm.Address, atm.IsActive);
            }


            using (XLWorkbook workbook = new XLWorkbook())
            {

                IXLWorksheet worksheet = workbook.Worksheets.Add(table);

                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(fileName);
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("File is ready. Do you want to open it?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult != MessageBoxResult.Yes)
                return;

            Process.Start(fileName);
        }
    }
}
