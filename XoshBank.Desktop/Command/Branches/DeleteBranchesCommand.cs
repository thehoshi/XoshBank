using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Branches
{
    public class DeleteBranchesCommand
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
            int index = _viewModel.SelectedBranch.ID - 1;

            _viewModel.DB.Branches.Delete(id);
            _viewModel.AllBranches.RemoveAt(index);
            _viewModel.Branches.RemoveAt(index);

            for (int i = index; i < _viewModel.Branches.Count; i++)
            {
                var item = _viewModel.Branches[i];
                var renumbered = new BranchUIModel
                {
                    ID = i + 1,
                    BranchName = item.BranchName,
                    City = item.City,
                    Address = item.Address,
                    ManagerName = item.ManagerName,
                    PhoneNumber = item.PhoneNumber,
                    EmployeeCount = item.EmployeeCount,
                    OpeningDate = item.OpeningDate,
                    Revenue = item.Revenue,
                    Expenses = item.Expenses
                };
                _viewModel.Branches[i] = renumbered;
                _viewModel.AllBranches[i] = renumbered;
            }

            _viewModel.SelectedBranch = null;
            _viewModel.CurrentBranch = new BranchFormModel();
            _viewModel.CurrentState = ViewState.Default;
            MessageBox.Show("Branch deleted successfully!", "Success", MessageBoxButton.OK);
        }
    }
}
