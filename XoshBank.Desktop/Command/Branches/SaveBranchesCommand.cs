
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Desktop.ViewModels;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Command.Branches
{
    public class SaveBranchesCommand : ICommand
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
            if (_viewModel.CurrentBranch == null)
                _viewModel.CurrentBranch = new BranchFormModel();

            var result = MessageBox.Show("Are you sure you want to save?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;

            var source = _viewModel.CurrentBranch;

            var branch = new Branch
            {
                BranchName = source.BranchName,
                City = source.City,
                Address = source.Address,
                ManagerName = source.ManagerName,
                PhoneNumber = source.PhoneNumber,
                EmployeeCount = source.EmployeeCount,
                OpeningDate = source.OpeningDate,
                Revenue = source.Revenue,
                Expenses = source.Expenses,
            };

            var isEdit = _viewModel.SelectedBranch != null && _viewModel.SelectedBranch.ID > 0;
            if (isEdit)
            {
                branch.ID = _viewModel.SelectedBranch.ID;
                _viewModel.DB.Branches.Update(branch);

                int index = _viewModel.Branches.IndexOf(_viewModel.SelectedBranch);
                var updated = new BranchUIModel
                {
                    ID = branch.ID,
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
                if (index >= 0)
                {
                    _viewModel.AllBranches[index] = updated;
                    _viewModel.Branches[index] = updated;
                }
                MessageBox.Show("Branch updated successfully!", "Success", MessageBoxButton.OK);
            }
            else
            {
                _viewModel.DB.Branches.Insert(branch);
                var newModel = new BranchUIModel
                {
                    ID = branch.ID,
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
