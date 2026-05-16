using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using XoshBank.Command.Employees;
using XoshBank.Core.Repositories;
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

            CurrentState = ViewState.Default;
            CurrentEmployee = new EmployeeFormModel();
            Employees = new ObservableCollection<EmployeeUIModel>();
            AllEmployees = new List<EmployeeUIModel>();
        }

        #region properties

        public IUnitOfWork Db => _db;

        private ViewState _currentState;
        public ViewState CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                OnPropertyChanged(nameof(CurrentState));
            }
        }

        private EmployeeFormModel _currentEmployee;
        public EmployeeFormModel CurrentEmployee
        {
            get => _currentEmployee;
            set
            {
                _currentEmployee = value;
                OnPropertyChanged(nameof(CurrentEmployee));
            }
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
                        EmployeeId = value.EmployeeId,
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        Email = value.Email,
                        Phone = value.Phone,
                        Position = value.Position,
                        Salary = value.Salary ?? 0,
                        HireDate = value.HireDate ?? System.DateTime.Now,
                        IsActive = value.IsActive ?? false,
                        DeletedAt = value.DeletedAt
                    };
                }
                else
                {
                    CurrentState = ViewState.Default;
                    CurrentEmployee = new EmployeeFormModel();
                }

               
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private ObservableCollection<EmployeeUIModel> _employees;
        public ObservableCollection<EmployeeUIModel> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
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
                        if (
                            e.FirstName?.ToUpper().Contains(upper) == true ||
                            e.LastName?.ToUpper().Contains(upper) == true ||
                            e.Email?.ToUpper().Contains(upper) == true ||
                            e.Position?.ToUpper().Contains(upper) == true ||
                            e.Phone?.ToUpper().Contains(upper) == true ||
                            (e.Salary.HasValue &&
                             e.Salary.Value.ToString().ToUpper().Contains(upper)) ||

                            (e.HireDate.HasValue &&
                             e.HireDate.Value.ToString("yyyy-MM-dd")
                             .ToUpper()
                             .Contains(upper)) ||

                            (e.IsActive.HasValue &&
                             e.IsActive.Value.ToString()
                             .ToUpper()
                             .Contains(upper))
                           )
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

        public AddEmployeesCommand AddCommand
            => new AddEmployeesCommand(this);

        public SaveEmployeesCommand SaveCommand
            => new SaveEmployeesCommand(this);

        public EditEmployeesCommand EditCommand
            => new EditEmployeesCommand(this);

        public RejectEmployeesCommand RejectCommand
            => new RejectEmployeesCommand(this);

        public DeleteEmployeesCommand DeleteCommand
            => new DeleteEmployeesCommand(this);

        public ExportEmployeesCommand ExportCommand
            => new ExportEmployeesCommand(this);

        #endregion

        #region property changed

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
