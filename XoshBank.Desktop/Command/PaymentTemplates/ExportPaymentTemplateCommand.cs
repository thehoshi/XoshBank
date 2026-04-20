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
using XoshBank.ViewModels;

namespace XoshBank.Command.PaymentTemplates
{
    public class ExportPaymentTemplateCommand : ICommand
    {
        private readonly PaymentTemplatesControlViewModel viewModel;

        public ExportPaymentTemplateCommand(PaymentTemplatesControlViewModel viewModel)
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

            var table = new DataTable("PaymentTemplates");

            table.Columns.Add("No");
            table.Columns.Add("TemplateName");
            table.Columns.Add("ServiceName");
            table.Columns.Add("CustomerCode");
            table.Columns.Add("Amount");
            table.Columns.Add("IsActive");

            foreach (var template in viewModel.Templates)
            {
                table.Rows.Add(template.No, template.TemplateName, template.ServiceName, template.CustomerCode, template.Amount, template.IsActive);
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
