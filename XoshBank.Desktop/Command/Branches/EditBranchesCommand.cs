using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;

namespace XoshBank.Command.Branches
{
    public class EditBranchesCommand
    {
        private readonly BranchesControlViewModel _viewModel;
        public EditBranchesCommand(BranchesControlViewModel viewModel)
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
            if (_viewModel.SelectedBranch == null)
            {
                MessageBox.Show("Please select a branch to edit.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _viewModel.CurrentState = ViewState.Edit;
        }
    }
}
