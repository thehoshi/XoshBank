using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using XoshBank.Models;
using XoshBank.Desktop.ViewModels;

namespace XoshBank.Command.Cards
{
    public class ExportCardCommand : ICommand
    {
        private readonly CardsControlViewModel viewModel;

        public ExportCardCommand(CardsControlViewModel viewModel)
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

            var table = new DataTable("Cards");
            table.Columns.Add("CardId");
            table.Columns.Add("CardNumber");
            table.Columns.Add("ExpiryDate");
            table.Columns.Add("CVV");
            table.Columns.Add("CardType");
            table.Columns.Add("Balance");
            table.Columns.Add("AccountId");
            table.Columns.Add("IsActive");
            table.Columns.Add("CreatedDate");
            table.Columns.Add("DeletedAt");

            foreach (var card in viewModel.Cards)
            {
                table.Rows.Add(card.CardId, card.CardNumber, card.ExpiryDate, card.CVV,
                               card.CardType, card.Balance, card.AccountId,
                               card.IsActive, card.CreatedDate, card.DeletedAt);
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
