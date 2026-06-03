namespace XoshBank.Web.Models
{
    public class CustomerUIModel
    {
        public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
    }
    public class CustomerModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Address { get; set; }
        public string FINCode { get; set; } = "";
    }
}
