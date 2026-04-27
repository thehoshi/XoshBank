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

namespace XoshBank.Command.Branches
{
    public class DeleteBranchesCommand : ICommand
    {
        private readonly BranchesControlViewModel _viewModel;
        public DeleteBranchesCommand(BranchesControlViewModel viewModel)
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
            if (_viewModel.SelectedBranch == null) return;

            var result = MessageBox.Show("Are you sure you want to delete this branch?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) return;

            int id = _viewModel.SelectedBranch.ID;
            int index = _viewModel.Branches.IndexOf(_viewModel.SelectedBranch);

            _viewModel.DB.Branches.Delete(id);
            _viewModel.AllBranches.RemoveAt(index);
            _viewModel.Branches.RemoveAt(index);

            _viewModel.SelectedBranch = null;
            _viewModel.CurrentBranch = new BranchFormModel();
            _viewModel.CurrentState = ViewState.Default;
            MessageBox.Show("Branch deleted successfully!", "Success", MessageBoxButton.OK);
        }
    }
}
