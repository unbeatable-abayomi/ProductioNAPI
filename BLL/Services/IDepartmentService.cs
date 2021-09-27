using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Request;
using DLO.DBContext;
using DLO.Model;
using DLO.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IDepartmentService
    {
        Task <Department> InsertAsync(DepartmentInsertRequestViewModel request);
        Task<List<Department>> GetAllAsync();
        Task <Department> DeleteAsync(string code);
       
        Task <Department> GetAsync(string code);
        Task<Department> UpdateAsync(string code,Department department);
        Task<bool> IsCodeExists(string code);
        
        Task<bool> IsNameExists(string name);
    }

    public class DepartmentService : IDepartmentService
    {
        //private readonly ApplicationDbContext _dbContext;
        
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> InsertAsync(DepartmentInsertRequestViewModel request)
        {
            Department department = new Department();
            department.Name = request.Name;
            department.Code = request.Code;
            return await _departmentRepository.InsertAsync(department);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }
        
        public async Task<Department> DeleteAsync(string code)
        {

            return await _departmentRepository.DeleteAsync(code);
        }
        public async Task<Department> GetAsync(string code)
        {

            return await _departmentRepository.GetAsync(code);
        }
        
        public async Task<Department> UpdateAsync(string code,Department department)
        {

            return await _departmentRepository.UpdateAsync(code,department);        }

        public async Task<bool> IsCodeExists(string code)
        {
            var department = await _departmentRepository.FindByCode(code);
            if (department == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var department = await _departmentRepository.FindByName(name);
            if (department == null)
            {
                return true;
            }

            return false;
        }
    }
}