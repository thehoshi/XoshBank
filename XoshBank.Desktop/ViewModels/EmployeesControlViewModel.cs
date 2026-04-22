using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XoshBank.Core.Repositories;
using XoshBank.Command.Employees;
using XoshBank.Enums;
using XoshBank.Models;

namespace XoshBank.Desktop.ViewModels
{
    public class EmployeesControlViewModel : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _db;
        public EmployeesControlViewModel(IUnitOfWork db)
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

        private EmployeeFormModel _currentEmployee;
        public EmployeeFormModel CurrentEmployee
        {
            get => _currentEmployee;
            set { _currentEmployee = value; OnPropertyChanged(nameof(CurrentEmployee)); }
        }

        private EmployeeUIModel _selectedEmployee;
        public EmployeeUIModel SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));

                if (value != null)
                {
                    CurrentState = ViewState.Selected;
                    CurrentEmployee = new EmployeeFormModel
                    {
                        FirstName = SelectedEmployee.FirstName,
                        LastName = SelectedEmployee.LastName,
                        Email = SelectedEmployee.Email,
                        Phone = SelectedEmployee.Phone,
                        Position = SelectedEmployee.Position,
                        Salary = SelectedEmployee.Salary
                    };
                }
                else
                {
                    CurrentState = ViewState.Default;
                    CurrentEmployee = new EmployeeFormModel();
                }
            }
        }

        private ObservableCollection<EmployeeUIModel> _employees;
        public ObservableCollection<EmployeeUIModel> Employees
        {
            get => _employees;
            set { _employees = value; OnPropertyChanged(nameof(Employees)); }
        }

        public List<EmployeeUIModel> AllEmployees { get; set; }

        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));

                var filtered = new List<EmployeeUIModel>();

                if (string.IsNullOrWhiteSpace(SearchValue))
                {
                    Employees = new ObservableCollection<EmployeeUIModel>(AllEmployees);
                }
                else
                {
                    var upper = SearchValue.ToUpper();
                    foreach (EmployeeUIModel e in AllEmployees)
                    {
                        if (e.FirstName?.ToUpper().Contains(upper) == true ||
                            e.LastName?.ToUpper().Contains(upper) == true ||
                            e.Email?.ToUpper().Contains(upper) == true ||
                            e.Position?.ToUpper().Contains(upper) == true)
                        {
                            filtered.Add(e);
                        }
                    }
                    Employees = new ObservableCollection<EmployeeUIModel>(filtered);
                }
            }
        }

        #endregion

        #region commands

        public AddEmployeeCommand Add => new AddEmployeeCommand(this);
        public SaveEmployeeCommand Save => new SaveEmployeeCommand(this);
        public EditEmployeeCommand Edit => new EditEmployeeCommand(this);
        public RejectEmployeeCommand Reject => new RejectEmployeeCommand(this);
        public DeleteEmployeeCommand Delete => new DeleteEmployeeCommand(this);
        public ExportEmployeeCommand Export => new ExportEmployeeCommand(this);
        #endregion

        #region property changed

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
