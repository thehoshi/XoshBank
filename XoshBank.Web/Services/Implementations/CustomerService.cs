using Microsoft.AspNetCore.Identity;
using XoshBank.Core.Repositories;
using XoshBank.Web.Models;
using XoshBank.Web.Services.Interfaces;

namespace XoshBank.Web.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _db;

        public CustomerService(IUnitOfWork db)
        {
            _db = db;
        }

        public List<CustomerModel> Get()
        {
            var customers = _db.Customers.GetAll();
            var customerModels = new List<CustomerModel>();

            for (int i = 0; i < customers.Count; i++)
            {
                var c = customers[i];
                customerModels.Add(new CustomerModel
                {
                    No = i + 1,
                    Id = c.ID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Email = c.Email,
                    DateOfBirth = c.DateOfBirth,
                    FINCode = c.FINCode

                });
            }

            return customerModels;
        }
    }
}
