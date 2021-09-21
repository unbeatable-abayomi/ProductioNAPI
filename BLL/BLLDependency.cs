using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public static class BLLDependency
    {
        public  static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            
            
            //repository dependency

            //repository dependency

            services.AddTransient<IDepartmentService, DepartmentService>();
            //services.AddTransient<IStudentRepository, StudentRepository>();
        }
    }
}