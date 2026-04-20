using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;

namespace XoshBank.Command.Branches
{
    public class RejectBranchesCommand
    {
        private readonly BranchesControlViewModel _viewModel;
        public RejectBranchesCommand(BranchesControlViewModel viewModel)
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
            _viewModel.CurrentState = ViewState.Reject;
        }
    }
}
