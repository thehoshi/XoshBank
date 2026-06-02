using Microsoft.EntityFrameworkCore;
using XoshBank.Core.Entities; 

namespace XoshBank.Web.Models
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
