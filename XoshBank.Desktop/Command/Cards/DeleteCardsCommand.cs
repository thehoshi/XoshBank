using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Cards
{
    public class DeleteCardsCommand : ICommand
    {
        private readonly CardsControlViewModel _viewModel;

        public DeleteCardsCommand(CardsControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedCard == null) return;

            var result = MessageBox.Show("Are you sure you want to delete this card?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;

            int id = _viewModel.SelectedCard.CardId;

            _viewModel.DB.Cards.Delete(id);

            var inAll = _viewModel.AllCards.FirstOrDefault(c => c.CardId == id);
            var inFiltered = _viewModel.Cards.FirstOrDefault(c => c.CardId == id);

            if (inAll != null) _viewModel.AllCards.Remove(inAll);
            if (inFiltered != null) _viewModel.Cards.Remove(inFiltered);

            _viewModel.SelectedCard = null;
            _viewModel.CurrentCard = new CardFormModel();
            _viewModel.CurrentState = ViewState.Default;

            MessageBox.Show("Card deleted successfully!", "Success", MessageBoxButton.OK);
        }
    }
}

