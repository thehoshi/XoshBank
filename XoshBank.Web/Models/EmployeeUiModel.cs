namespace XoshBank.Web.Models
{
    public class EmployeeUiModel
    {
        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
    }

    public class EmployeeModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Position { get; set; } = "";
    }
}
