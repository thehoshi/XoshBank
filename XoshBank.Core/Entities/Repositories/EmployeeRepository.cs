using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoshBankCore;

namespace XoshBankCore.Entities.Repositories 
{ 

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();

  
        public void Add(Employee employee) => _employees.Add(employee);

  
        public Employee GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

   
        public IEnumerable<Employee> GetAll() => _employees;

     
        public void Update(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing != null)
            {
                existing.FirstName = employee.FirstName;
                existing.LastName = employee.LastName;
                existing.Position = employee.Position;
                existing.HireDate = employee.HireDate;
            }
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
                _employees.Remove(employee);
        }
    }
}
