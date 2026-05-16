using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;

namespace XoshBank.Command.Cards
{
    public class ExportCardsCommand : ICommand
    {
        private readonly CardsControlViewModel _viewModel;

        public ExportCardsCommand(CardsControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _viewModel.Cards.Count > 0;

        public void Execute(object parameter)
        {
            var dialog = new SaveFileDialog
            {
                Title = "Export Cards",
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                FileName = "cards.csv"
            };

            if (dialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(dialog.FileName))
                {
                    writer.WriteLine("CardId,CardNumber,ExpiryDate,CVV,CardType,Balance,AccountId,IsActive,CreatedDate,DeletedAt");

                    foreach (var c in _viewModel.Cards)
                    {
                        writer.WriteLine($"{c.CardId},{c.CardNumber},{c.ExpiryDate:yyyy-MM-dd},{c.CVV},{c.CardType},{c.Balance},{c.AccountId},{c.IsActive},{c.CreatedDate},{c.DeletedAt}");
                    }
                }

                MessageBox.Show("Cards exported successfully!", "Success", MessageBoxButton.OK);
            }
        }
    }
}
