using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Models;

namespace XoshBank.Command.Cards
{
    public class ExportCardsCommand : ICommand
    {
        private readonly CardsControlViewModel _viewModel;

        public ExportCardsCommand(CardsControlViewModel viewModel)
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
                    $"Cards_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv");

                using (var writer = new StreamWriter(path))
                {
                    // Header
                    writer.WriteLine("CardId,CardNumber,ExpiryDate,CVV,CardType,Balance,AccountId,IsActive,CreatedDate,DeletedAt");

                    // Rows
                    foreach (var c in _viewModel.Cards)
                    {
                        writer.WriteLine($"{c.CardId}," +
                                         $"{c.CardNumber}," +
                                         $"{c.ExpiryDate:dd.MM.yyyy}," +
                                         $"{c.CVV}," +
                                         $"{c.CardType}," +
                                         $"{c.Balance}," +
                                         $"{c.AccountId}," +
                                         $"{c.IsActive}," +
                                         $"{c.CreatedDate:dd.MM.yyyy}," +
                                         $"{c.DeletedAt:dd.MM.yyyy}");
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