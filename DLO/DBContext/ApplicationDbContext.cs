using DLO.Model;
using Microsoft.EntityFrameworkCore;

namespace DLO.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}