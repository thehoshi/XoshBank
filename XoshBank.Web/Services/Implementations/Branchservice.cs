using XoshBank.Core.Repositories;
using XoshBank.Web.Models;
using XoshBank.Web.Services.Interfaces;

namespace XoshBank.Web.Services.Implementations
{
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork _db;

        public BranchService(IUnitOfWork db)
        {
            _db = db;
        }

        public List<BranchModel> Get()
        {
            var branches = _db.Branches.GetAll();
            var branchModels = new List<BranchModel>();

            for (int i = 0; i < branches.Count; i++)
            {
                var b = branches[i];

                branchModels.Add(new BranchModel
                {
                    No = i + 1,
                    Id = b.ID,
                    BranchName = b.BranchName,
                    City = b.City,
                    Address = b.Address,
                    ManagerName = b.ManagerName,
                    PhoneNumber = b.PhoneNumber,
                    EmployeeCount = b.EmployeeCount,
                    OpeningDate = b.OpeningDate,
                    Revenue = b.Revenue,
                    Expenses = b.Expenses
                });
            }

            return branchModels;
        }
    }
}