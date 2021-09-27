using System;
using System.Threading;
using System.Threading.Tasks;
using BLL.Services;
using DLO.Repositories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Request
{
    public class DepartmentInsertRequestViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    
    public class DepartmentInsertRequestViewModelValidator : AbstractValidator<DepartmentInsertRequestViewModel>
    {
         private readonly IServiceProvider _serviceProvider;
        public DepartmentInsertRequestViewModelValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RuleFor(x => x.Name).NotEmpty().NotEmpty().MinimumLength(4).MaximumLength(25)
                .MustAsync(NameExists).WithMessage("name exists in our system");
            RuleFor(x => x.Code).NotEmpty().NotEmpty().MinimumLength(3).MaximumLength(10)
                .MustAsync(CodeExists).WithMessage("code exists in our system");
            
        }

        private async Task<bool> CodeExists(string code, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(code))
            {
                return true;
            }

            var requiredService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requiredService.IsCodeExists(code);
        }
        
        private async Task<bool> NameExists(string name, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(name))
            {
                return true;
            }

            var requiredService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requiredService.IsNameExists(name);
        }
    }
}