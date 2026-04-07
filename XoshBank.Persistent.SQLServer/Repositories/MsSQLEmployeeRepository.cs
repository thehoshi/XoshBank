using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using XoshBank.Entities;
using XoshBankCore.Entities.Repositories;

namespace XoshBank.Persistent.SQLServer
{
    public class MsSqlEmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public MsSqlEmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>();
        }

        public Employee GetById(int id)
        {
            return null;
        }

        public void Insert(Employee entity)
        {
        }

        public void Update(Employee entity)
        {
        }

        public void Delete(int id)
        {
        }

        public List<Employee> GetActiveEmployees()
        {
            return new List<Employee>();
        }
    }

}
