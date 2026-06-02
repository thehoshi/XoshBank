using XoshBank.Core.Repositories;
using XoshBank.Web.Models;
using XoshBank.Web.Services.Interfaces;

namespace XoshBank.Web.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _db;
        public EmployeeService(IUnitOfWork db)
        {
            _db = db;
        }

        public List<EmployeeModel> Get()
        {
            var employees = _db.Employees.GetAll();
            var employeeModels = new List<EmployeeModel>();

            for (int i = 0; i < employees.Count; i++)
            {
                var emp = employees[i];
                employeeModels.Add(new EmployeeModel
                {
                    No = i + 1,
                    Id = emp.ID,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Email = emp.Email,
                    Position = emp.Position
                });
            }

            return employeeModels;
        }
    }
}
