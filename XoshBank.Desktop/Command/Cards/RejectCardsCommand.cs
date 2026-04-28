using System;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Cards
{
    public class RejectCardsCommand : ICommand
    {
        private readonly CardsControlViewModel _viewModel;

        public RejectCardsCommand(CardsControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var result = MessageBox.Show("Are you sure you want to cancel changes?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) return;

            // Reset form and state
            _viewModel.SelectedCard = null;
            _viewModel.CurrentCard = new CardFormModel();
            _viewModel.CurrentState = ViewState.Default;

            MessageBox.Show("Changes have been discarded.",
                "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
