using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        //GET
 

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DepartmentStatic.GetAllDepartments());
        }


        [HttpGet("{code}")]
        public IActionResult GetA(string code)
        {
            return Ok(DepartmentStatic.GetADepartment(code));
        }

        [HttpPost]
        public IActionResult Insert(Department department)
        {
            return Ok(DepartmentStatic.InsertDepartment(department));
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, Department department)
        {
            return Ok(DepartmentStatic.UpdateDepartment(code,department));
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok(DepartmentStatic.DeleteDepartment(code));
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
