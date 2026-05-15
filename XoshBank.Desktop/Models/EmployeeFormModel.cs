using System;
using System.ComponentModel;

namespace XoshBank.Models
{
    public class EmployeeFormModel : INotifyPropertyChanged
    {
        private int _employeeId;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _position;
        private decimal? _salary;       
        private DateTime? _hireDate;    
        private bool? _isActive;        
        private DateTime? _deletedAt;   

        public int EmployeeId
        {
            get => _employeeId;
            set { _employeeId = value; OnPropertyChanged(nameof(EmployeeId)); }
        }
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        public string Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }
        public string Position
        {
            get => _position;
            set { _position = value; OnPropertyChanged(nameof(Position)); }
        }
        public decimal? Salary
        {
            get => _salary;
            set { _salary = value; OnPropertyChanged(nameof(Salary)); }
        }
        public DateTime? HireDate
        {
            get => _hireDate;
            set { _hireDate = value; OnPropertyChanged(nameof(HireDate)); }
        }
        public bool? IsActive
        {
            get => _isActive;
            set { _isActive = value; OnPropertyChanged(nameof(IsActive)); }
        }
        public DateTime? DeletedAt
        {
            get => _deletedAt;
            set { _deletedAt = value; OnPropertyChanged(nameof(DeletedAt)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
