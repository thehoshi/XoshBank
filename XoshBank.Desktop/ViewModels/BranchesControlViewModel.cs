using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XoshBank.Core.Repositories;
using XoshBank.Command.Branches;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Desktop.ViewModels
{
    public class BranchesControlViewModel : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _db;
        public BranchesControlViewModel(IUnitOfWork db)
        {
            _db = db;
        }

        #region properties

        public IUnitOfWork DB => _db;

        private ViewState _currentState;
        public ViewState CurrentState
        {
            get => _currentState;
            set { _currentState = value; OnPropertyChanged(nameof(CurrentState)); }
        }

        private BranchFormModel _currentBranch;
        public BranchFormModel CurrentBranch
        {
            get => _currentBranch;
            set { _currentBranch = value; OnPropertyChanged(nameof(CurrentBranch)); }
        }

        private BranchUIModel _selectedBranch;
        public BranchUIModel SelectedBranch
        {
            get => _selectedBranch;
            set
            {
                _selectedBranch = value;
                OnPropertyChanged(nameof(SelectedBranch));

                if (value != null)
                {
                    CurrentState = ViewState.Selected;
                    CurrentBranch = new BranchFormModel
                    {
                        BranchName = SelectedBranch.BranchName,
                        City = SelectedBranch.City,
                        Address = SelectedBranch.Address,
                        ManagerName = SelectedBranch.ManagerName,
                        PhoneNumber = SelectedBranch.PhoneNUmber,
                        EmployeeCount = SelectedBranch.EmployeeCount,
                        OpeningDate = SelectedBranch.OpeningDate,
                        Revenue = SelectedBranch.Revenue,
                        Expenses = SelectedBranch.Expenses
                    };
                }
                else
                {
                    CurrentState = ViewState.Default;
                    CurrentBranch = new BranchFormModel();
                }
            }
        }

        private ObservableCollection<BranchUIModel> _branches;
        public ObservableCollection<BranchUIModel> Branches
        {
            get => _branches;
            set { _branches = value; OnPropertyChanged(nameof(Branches)); }
        }

        public List<BranchUIModel> AllBranches { get; set; }

        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));

                var filtered = new List<BranchUIModel>();

                if (string.IsNullOrWhiteSpace(SearchValue))
                {
                    Branches = new ObservableCollection<BranchUIModel>(AllBranches);
                }
                else
                {
                    var upper = SearchValue.ToUpper();
                    foreach (BranchUIModel b in AllBranches)
                    {
                        if (b.BranchName?.ToUpper().Contains(upper) == true ||
                            b.City?.ToUpper().Contains(upper) == true ||
                            b.ManagerName?.ToUpper().Contains(upper) == true)
                        {
                            filtered.Add(b);
                        }
                    }
                    Branches = new ObservableCollection<BranchUIModel>(filtered);
                }
            }
        }

        #endregion

        #region commands

        public AddBranchesCommand Add => new AddBranchesCommand(this);
        public SaveBranchesCommand Save => new SaveBranchesCommand(this);
        public EditBranchesCommand Edit => new EditBranchesCommand(this);
        public RejectBranchesCommand Reject => new RejectBranchesCommand(this);
        public DeleteBranchesCommand Delete => new DeleteBranchesCommand(this);

        #endregion

        #region property changed

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}