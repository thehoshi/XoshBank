using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Branches
{
    public class AddBranchesCommand : ICommand
    {
        private readonly BranchesControlViewModel _viewModel;
        public AddBranchesCommand(BranchesControlViewModel viewModel)
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
            _viewModel.CurrentBranch = new BranchFormModel(); 
            _viewModel.SelectedBranch = null;                 
            _viewModel.CurrentState = ViewState.Add;
        }
    }
}
