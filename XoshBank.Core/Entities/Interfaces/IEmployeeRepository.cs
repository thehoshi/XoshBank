using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace XoshBankCore
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);         
        Employee GetById(int id);             
        IEnumerable<Employee> GetAll();      
        void Update(Employee employee);      
        void Delete(int id);                 
    }
}
