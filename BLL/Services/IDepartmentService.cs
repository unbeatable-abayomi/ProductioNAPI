using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Request;
using DLO.DBContext;
using DLO.Model;
using DLO.Repositories;
using Microsoft.EntityFrameworkCore;
using Utility.Exceptions;

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
            await _departmentRepository.CreateAsync(department);
            //return await _departmentRepository.InsertAsync(department);
            if (await _departmentRepository.SaveCompletedAsync())
            {
                return department;
            }

            throw new ApplicationValidationException("department insert has some problem");

        }

        public async Task<List<Department>> GetAllAsync()
        {
           //return await _departmentRepository.GetAllAsync();
           return await _departmentRepository.GetList();
        }
        
        public async Task<Department> DeleteAsync(string code)
        {
            var department = await _departmentRepository.FindSingleAsync(X => X.Code == code);
            if (department == null)
            {
              throw  new ApplicationValidationException("department not found");
            }

             _departmentRepository.Delete(department);
             if (await _departmentRepository.SaveCompletedAsync())
             {
                 return department;
             }
            throw new Exception("some problem in deleting data");
        }
        public async Task<Department> GetAsync(string code)
        {

            var department =  await _departmentRepository.FindSingleAsync(X => X.Code == code);
            if (department == null)
            {
                throw  new ApplicationValidationException("department not found");
            }

            return department;
        } 
        public async Task<Department> UpdateAsync(string code,Department adepartment)
        {
            var department = await _departmentRepository.FindSingleAsync(X => X.Code == code);
            
          if (department == null)
          {
              throw  new ApplicationValidationException("department no found");
          }

  if (!string.IsNullOrWhiteSpace(adepartment.Code))
  {
      var existsAlreadyCode =  await _departmentRepository.FindSingleAsync(X => X.Code == code);
      if (existsAlreadyCode != null)
      {
          throw  new ApplicationValidationException("Your updated code already present in our system");
      }

      department.Code = adepartment.Code;
  }
  if (!string.IsNullOrWhiteSpace(adepartment.Name))
  {
      var existsAlreadyCode = await _departmentRepository.FindSingleAsync(X => X.Name == adepartment.Name);
      if (existsAlreadyCode != null)
      {
          throw  new ApplicationValidationException("Your updated name already present in our system");
      }

      department.Name = adepartment.Name;
  }

         _departmentRepository.Update(department);

  if (await _departmentRepository.SaveCompletedAsync())
  {
      return department;
  }

  
  throw  new ApplicationValidationException("In update have some problem");
  
            /*var department = await _departmentRepository.GetAsync(code);
            if (department == null)
            {
                throw  new ApplicationValidationException("department no found");
            }

            if (!string.IsNullOrWhiteSpace(adepartment.Code))
            {
                var existsAlreadyCode = await _departmentRepository.FindByCode(adepartment.Code);
                if (existsAlreadyCode != null)
                {
                    throw  new ApplicationValidationException("Your updated code already present in our system");
                }

                department.Code = adepartment.Code;
            }
            if (!string.IsNullOrWhiteSpace(adepartment.Name))
            {
                var existsAlreadyCode = await _departmentRepository.FindByName(adepartment.Name);
                if (existsAlreadyCode != null)
                {
                    throw  new ApplicationValidationException("Your updated name already present in our system");
                }

                department.Name = adepartment.Name;
            }

            if (await _departmentRepository.UpdateAsync(department))
            {
                return department;
            }
            throw  new ApplicationValidationException("In update have some problem");
            ;*/

        }

        public async Task<bool> IsCodeExists(string code)
        {
            var department = await _departmentRepository.FindSingleAsync(X => X.Code == code);
            if (department == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var department = await _departmentRepository.FindSingleAsync(X => X.Name == name);;
            if (department == null)
            {
                return true;
            }

            return false;
        }
    }
}