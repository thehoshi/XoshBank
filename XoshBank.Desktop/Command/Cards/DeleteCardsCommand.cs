using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedCard == null) return;

            var result = MessageBox.Show("Are you sure you want to delete this card?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;

            int id = _viewModel.SelectedCard.CardId;
            int index = _viewModel.Cards.IndexOf(_viewModel.SelectedCard);

            
            _viewModel.DB.Cards.Delete(id);
            _viewModel.AllCards.RemoveAt(index);
            _viewModel.Cards.RemoveAt(index);

            
            _viewModel.SelectedCard = null;
            _viewModel.CurrentCard = new CardFormModel();
            _viewModel.CurrentState = ViewState.Default;

            MessageBox.Show("Card deleted successfully!", "Success", MessageBoxButton.OK);
        }
    }
}
