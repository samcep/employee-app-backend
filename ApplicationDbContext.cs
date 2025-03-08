using employee_app.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_app
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        
    }
}
