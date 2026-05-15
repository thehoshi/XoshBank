using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XoshBank.Command.Loans;
using XoshBank.Core.Repositories;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Desktop.ViewModels
{
    public class LoansControlViewModel : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _db;

        public LoansControlViewModel(IUnitOfWork db)
        {
            _db = db;
        }

        public IUnitOfWork DB => _db;


        private ViewState _currentState;
        public ViewState CurrentState
        {
            get => _currentState;
            set { _currentState = value; OnPropertyChanged(nameof(CurrentState)); }
        }


        private LoanFormModel _currentLoan;
        public LoanFormModel CurrentLoan
        {
            get => _currentLoan;
            set { _currentLoan = value; OnPropertyChanged(nameof(CurrentLoan)); }
        }


        private LoanUIModel _selectedLoan;
        public LoanUIModel SelectedLoan
        {
            get => _selectedLoan;
            set
            {
                _selectedLoan = value;
                OnPropertyChanged(nameof(SelectedLoan));

                if (value != null)
                {
                    CurrentState = ViewState.Selected;
                    CurrentLoan = new LoanFormModel
                    {
                        CustomerID = value.CustomerID,
                        ApprovedBy = value.ApprovedBy,
                        BranchID = value.BranchID,
                        Amount = value.Amount,
                        InterestRate = value.InterestRate,
                        TotalAmount = value.TotalAmount,
                        MonthlyPayment = value.MonthlyPayment,
                        Status = value.Status,
                        LoanType = value.LoanType,
                        Currency = value.Currency,
                        StartDate = value.StartDate,
                        EndDate = value.EndDate,
                        ApprovalDate = value.ApprovalDate,
                        DurationMonths = value.DurationMonths,
                        LatePaymentFee = value.LatePaymentFee,
                        PenaltyRate = value.PenaltyRate,
                        Collateral = value.Collateral,
                        Notes = value.Notes
                    };
                }
                else
                {
                    CurrentState = ViewState.Default;
                    CurrentLoan = new LoanFormModel();
                }
            }
        }

        private ObservableCollection<LoanUIModel> _loans;
        public ObservableCollection<LoanUIModel> Loans
        {
            get => _loans;
            set { _loans = value; OnPropertyChanged(nameof(Loans)); }
        }

        public List<LoanUIModel> AllLoans { get; set; }


        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));

                if (string.IsNullOrWhiteSpace(_searchText))
                {
                    Loans = new ObservableCollection<LoanUIModel>(AllLoans);
                    return;
                }

                var upper = _searchText.ToUpper();
                var filtered = new List<LoanUIModel>();

                foreach (var l in AllLoans)
                {
                    if (l.Status?.ToUpper().Contains(upper) == true ||
                        l.LoanType?.ToUpper().Contains(upper) == true ||
                        l.Currency?.ToUpper().Contains(upper) == true ||
                        l.CustomerID.ToString().Contains(upper) ||
                        l.No.ToString().Contains(upper))
                    {
                        filtered.Add(l);
                    }
                }

                Loans = new ObservableCollection<LoanUIModel>(filtered);
            }
        }


        public AddLoansCommand AddCommand => new AddLoansCommand(this);
        public SaveLoansCommand SaveCommand => new SaveLoansCommand(this);
        public EditLoansCommand EditCommand => new EditLoansCommand(this);
        public RejectLoansCommand RejectCommand => new RejectLoansCommand(this);
        public DeleteLoansCommand DeleteCommand => new DeleteLoansCommand(this);
        public ExportLoansCommand ExportCommand => new ExportLoansCommand(this);


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}