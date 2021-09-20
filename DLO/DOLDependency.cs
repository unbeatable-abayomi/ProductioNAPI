using DLO.DBContext;
using DLO.Model;
using DLO.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLO
{
    public static class DOLDependency
    {
      public  static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            //repository dependency

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
        }
    }
}