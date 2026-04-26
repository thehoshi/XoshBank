using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using XoshBank.Core.Entities;
using XoshBank.Core.Repositories;
using XoshBank.ViewModels;
using XoshBank.Desktop.Views.UserControls;
using XoshBank.Views.UserControls;
using XoshBank.Enums;
using XoshBank.Models;
using XoshBank.Desktop.ViewModels;

namespace XoshBank.Command.Branches
{
    public class OpenBranchesCommand : ICommand
    {
        private readonly IUnitOfWork _db;
        public OpenBranchesCommand(IUnitOfWork db)
        {
            _db = db;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            Views.UserControls.AccountsControl branchesControl = new Views.UserControls.AccountsControl();

            BranchesControlViewModel viewModel = new BranchesControlViewModel(_db);

            List<Branch> branches = _db.Branches.GetAll();

            List<BranchUIModel> branchUIModels = new List<BranchUIModel>();

            int no = 1;
            foreach (Branch branch in branches)
            {
                BranchUIModel branchUIModel = new BranchUIModel
                {
                    ID = no++,
                    BranchName = branch.BranchName,
                    City = branch.City,
                    Address = branch.Address,
                    ManagerName = branch.ManagerName,
                    PhoneNumber = branch.PhoneNumber,
                    EmployeeCount = branch.EmployeeCount,
                    OpeningDate = branch.OpeningDate,
                    Revenue = branch.Revenue,
                    Expenses = branch.Expenses,
                    DeletedAt = branch.DeletedAt
                };
                branchUIModels.Add(branchUIModel);
            }

            viewModel.AllBranches = branchUIModels;
            viewModel.Branches = new ObservableCollection<BranchUIModel>(branchUIModels);

            viewModel.CurrentBranch = new BranchFormModel();
            viewModel.CurrentState = ViewState.Default;

            branchesControl.DataContext = viewModel;

            Grid grid = (Grid)parameter;

            grid.Children.Clear();
            grid.Children.Add(branchesControl);
        }
    }
}
