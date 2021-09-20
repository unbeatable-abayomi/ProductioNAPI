using DLO.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLO.Repositories;

namespace API.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //DRY Dont repeat yourself

    //[ApiVersion("1.0")]
    //[ApiController]
    //[Route("api/v{version:apiVersion}/[controller]")]
    public class DepartmentController : MainApiController
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        //GET
 

        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            return Ok(await _departmentRepository.GetAllAsync());
        }


        [HttpGet("{code}")]
        public async Task<IActionResult> GetA(string code)
        {
            return Ok(await _departmentRepository.GetAsync(code));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Department department)
        {
            return Ok(await _departmentRepository.InsertAsync(department));
        }

        [HttpPut("{code}")]
        public async Task <IActionResult> Update(string code, Department department)
        {
            return Ok(await _departmentRepository.UpdateAsync(code,department));
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return Ok(await _departmentRepository.DeleteAsync(code));
        }


        public static class DepartmentStatic
        {
            private static List<Department> AllDepartments { get; set; } = new List<Department>();
      

            public static Department InsertDepartment(Department department)
            {
                    AllDepartments.Add(department);
                return department;
            }


            public static List<Department> GetAllDepartments()
            {
                return AllDepartments;
            }

            public static Department GetADepartment(string code)
            {
                return AllDepartments.FirstOrDefault(x => x.Code == code);
            }


            public static Department UpdateDepartment(string code, Department department)
            {
                Department result = new Department();
                foreach (var aDepartment in AllDepartments)
                {
                    if (code == aDepartment.Code)
                    {
                        aDepartment.Name = department.Name;
                        result = aDepartment;
                    }
                }

                return result;
            }


            public static Department DeleteDepartment(string code)
            {
                var department = AllDepartments.FirstOrDefault(x => x.Code == code);
                AllDepartments = AllDepartments.Where(x => x.Code != department.Code).ToList();
                return department;
            }

        };

    }
}
