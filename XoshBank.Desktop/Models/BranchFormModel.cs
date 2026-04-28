using System;
using System.ComponentModel;

namespace XoshBank.Models
{
    public class BranchFormModel : INotifyPropertyChanged
    {
        private int _id;
        private string _branchName;
        private string _city;
        private string _address;
        private string _managerName;
        private string _phoneNumber;
        private int? _employeeCount;
        private DateTime? _openingDate;
        private double? _revenue;
        private double? _expenses;
        private DateTime? _deletedAt;

        public int ID
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        public string BranchName
        {
            get => _branchName;
            set { _branchName = value; OnPropertyChanged(nameof(BranchName)); }
        }
        public string City
        {
            get => _city;
            set { _city = value; OnPropertyChanged(nameof(City)); }
        }
        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }
        public string ManagerName
        {
            get => _managerName;
            set { _managerName = value; OnPropertyChanged(nameof(ManagerName)); }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }
        public int? EmployeeCount
        {
            get => _employeeCount;
            set { _employeeCount = value; OnPropertyChanged(nameof(EmployeeCount)); }
        }
        public DateTime? OpeningDate
        {
            get => _openingDate;
            set { _openingDate = value; OnPropertyChanged(nameof(OpeningDate)); }
        }
        public double? Revenue
        {
            get => _revenue;
            set { _revenue = value; OnPropertyChanged(nameof(Revenue)); }
        }
        public double? Expenses
        {
            get => _expenses;
            set { _expenses = value; OnPropertyChanged(nameof(Expenses)); }
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