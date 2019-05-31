using Compose.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Compose.Web.Context
{
    public class EmploymentContext : DbContext
    {
        public EmploymentContext(DbContextOptions<EmploymentContext> contextOptions)
            : base(contextOptions)
        { }

        public DbSet<Company> Companies { get; set; }
    }
}