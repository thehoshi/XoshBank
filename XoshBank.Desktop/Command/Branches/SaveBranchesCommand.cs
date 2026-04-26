using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XoshBank.Core.Entities;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Branches
{
    public class SaveBranchesCommand
    {
        private readonly BranchesControlViewModel _viewModel;
        public SaveBranchesCommand(BranchesControlViewModel viewModel)
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
            var result = MessageBox.Show("Are you sure you want to save?",
    "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;

            var branch = new Branch
            {
                BranchName = _viewModel.CurrentBranch.BranchName,
                City = _viewModel.CurrentBranch.City,
                Address = _viewModel.CurrentBranch.Address,
                ManagerName = _viewModel.CurrentBranch.ManagerName,
                PhoneNumber = _viewModel.CurrentBranch.PhoneNumber,
                EmployeeCount = _viewModel.CurrentBranch.EmployeeCount,
                OpeningDate = _viewModel.CurrentBranch.OpeningDate,
                Revenue = _viewModel.CurrentBranch.Revenue,
                Expenses = _viewModel.CurrentBranch.Expenses,
            };

            if (_viewModel.SelectedBranch != null && _viewModel.SelectedBranch.ID > 0)
            {
                branch.ID = _viewModel.SelectedBranch.ID;
                _viewModel.DB.Branches.Update(branch);

                int index = _viewModel.SelectedBranch.ID - 1;
                var updated = new BranchUIModel
                {
                    ID = _viewModel.SelectedBranch.ID,
                    BranchName = branch.BranchName,
                    City = branch.City,
                    Address = branch.Address,
                    ManagerName = branch.ManagerName,
                    PhoneNumber = branch.PhoneNumber,
                    EmployeeCount = branch.EmployeeCount,
                    OpeningDate = branch.OpeningDate,
                    Revenue = branch.Revenue,
                    Expenses = branch.Expenses
                };
                _viewModel.AllBranches[index] = updated;
                _viewModel.Branches[index] = updated;
                MessageBox.Show("Branch updated successfully!", "Success", MessageBoxButton.OK);
            }
            else
            {
                _viewModel.DB.Branches.Insert(branch);
                var newModel = new BranchUIModel
                {
                    ID = _viewModel.AllBranches.Count + 1,
                    BranchName = branch.BranchName,
                    City = branch.City,
                    Address = branch.Address,
                    ManagerName = branch.ManagerName,
                    PhoneNumber = branch.PhoneNumber,
                    EmployeeCount = branch.EmployeeCount,
                    OpeningDate = branch.OpeningDate,
                    Revenue = branch.Revenue,
                    Expenses = branch.Expenses
                };
                _viewModel.AllBranches.Add(newModel);
                _viewModel.Branches.Add(newModel);
                MessageBox.Show("Branch added successfully!", "Success", MessageBoxButton.OK);
            }

            _viewModel.SelectedBranch = null;
            _viewModel.CurrentBranch = new BranchFormModel();
            _viewModel.CurrentState = ViewState.Default;
        }
    }
}
