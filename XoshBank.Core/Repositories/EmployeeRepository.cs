using System;
using System.Collections.Generic;
using System.Linq;

namespace XoshBankCore.Entities.Repositories 
{ 
    public class EmployeeRepository : IBaseRepository<Employee>
    {
        private readonly List<Employee> _employees = new List<Employee>();

  
        public void Add(Employee employee) => _employees.Add(employee);

  
        public Employee GetById(int id) => _employees.FirstOrDefault(e => e.ID == id);

     
        public void Update(Employee employee)
        {
            var existing = GetById(employee.ID);

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

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
