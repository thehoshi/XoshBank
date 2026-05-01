using System;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;

namespace XoshBank.Command.Cards
{
    public class EditCardsCommand : ICommand
    {
        private readonly CardsControlViewModel _viewModel;

        public EditCardsCommand(CardsControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedCard == null)
            {
                MessageBox.Show("Please select a card to edit.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _viewModel.CurrentState = ViewState.Edit;
        }
    }
}
