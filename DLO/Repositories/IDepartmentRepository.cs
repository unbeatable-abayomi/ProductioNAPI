using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLO.DBContext;
using DLO.Model;
using Microsoft.EntityFrameworkCore;

namespace DLO.Repositories
{
    public interface IDepartmentRepository
    {
       Task <Department> InsertAsync(Department department);
       Task<List<Department>> GetAllAsync();
       Task <Department> DeleteAsync(string code);
       
       Task <Department> GetAsync(string code);
       Task<Department> UpdateAsync(string code,Department department);

       Task<Department> FindByName(string name);
       
       Task<Department> FindByCode(string code);
       

    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> InsertAsync(Department department)
        {
           
           await _dbContext.Departments.AddAsync(department);
           await _dbContext.SaveChangesAsync();
           return department;
        }

        public async Task<List<Department>> GetAllAsync()
        {
          var departments = await _dbContext.Departments.ToListAsync();
          return departments;
        }
        
        public async Task<Department> DeleteAsync(string code)
        {

            var department = await _dbContext.Departments.FirstOrDefaultAsync(c => c.Code == code);
            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
            return department;
        }
        public async Task<Department> GetAsync(string code)
        {

            var department = await _dbContext.Departments.FirstOrDefaultAsync(c => c.Code == code);
            return department;
        }
        
        public async Task<Department> UpdateAsync(string code,Department department)
        {

            var findDepartment = await _dbContext.Departments.FirstOrDefaultAsync(c => c.Code == code);
            findDepartment.Name = department.Name;
            _dbContext.Departments.Update(findDepartment);
            await _dbContext.SaveChangesAsync();
            return findDepartment;
        }

        public async Task<Department> FindByName(string name)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Department> FindByCode(string code)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Code == code);
        }
    }
}