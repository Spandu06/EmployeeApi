using Employee.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmpModel> empModels { get; set; }
    }
}
