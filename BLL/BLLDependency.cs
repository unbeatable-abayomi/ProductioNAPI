using BLL.Request;
using BLL.Services;
using FluentValidation;
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
            services.AddTransient<IStudentService, StudentService>();
            //services.AddTransient<IStudentRepository, StudentRepository>();
            AllFluentValidationDependency(services);
        }

        private static void AllFluentValidationDependency(IServiceCollection services)
        {
            services.AddTransient<IValidator<DepartmentInsertRequestViewModel>,DepartmentInsertRequestViewModelValidator>();
        }
    }
}