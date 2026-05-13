using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XoshBank.Command.Loans;
using XoshBank.Core.Repositories;
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

        private ObservableCollection<LoanUIModel> _loans;
        public ObservableCollection<LoanUIModel> Loans
        {
            get => _loans;
            set { _loans = value; OnPropertyChanged(nameof(Loans)); }
        }

        public List<LoanUIModel> AllLoans { get; set; }

        private LoanUIModel _selectedLoan;
        public LoanUIModel SelectedLoan
        {
            get => _selectedLoan;
            set { _selectedLoan = value; OnPropertyChanged(nameof(SelectedLoan)); }
        }

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
                }
                else
                {
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
        }

        public ExportLoansCommand ExportCommand => new ExportLoansCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}