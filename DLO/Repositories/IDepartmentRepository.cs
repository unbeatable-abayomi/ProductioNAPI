using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLO.DBContext;
using DLO.Model;
using Microsoft.EntityFrameworkCore;

namespace DLO.Repositories
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
       /*Task <Department> InsertAsync(Department department);
       Task<List<Department>> GetAllAsync();
       Task <bool> DeleteAsync(Department department);
       
       Task <Department> GetAsync(string code);
       Task<bool> UpdateAsync(Department department);

       Task<Department> FindByName(string name);
       
       Task<Department> FindByCode(string code);*/
       

    }

    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        /*private readonly ApplicationDbContext _dbContext;
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
        
        public async Task<bool> DeleteAsync(Department department)
        {

           // var department = await _dbContext.Departments.FirstOrDefaultAsync(c => c.Code == code);
            _dbContext.Departments.Remove(department);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return true;
            } ;
            //await _dbContext.SaveChangesAsync();
            return false;
        }
        public async Task<Department> GetAsync(string code)
        {

            var department = await _dbContext.Departments.FirstOrDefaultAsync(c => c.Code == code);
            return department;
        }
        
        public async Task<bool> UpdateAsync(Department department)
        {

            //var findDepartment = await _dbContext.Departments.FirstOrDefaultAsync(c => c.Code == code);
            //findDepartment.Name = department.Name;
            _dbContext.Departments.Update(department);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return true;
            };
            return false;
        }

        public async Task<Department> FindByName(string name)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Department> FindByCode(string code)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Code == code);
        }*/
      
    }
}