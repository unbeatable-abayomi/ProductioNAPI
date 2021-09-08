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



    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {


        //GET
 

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get All Students");
        }


        [HttpGet("{code}")]
        public IActionResult GetA(string code)
        {
            return Ok("Get this" + code + "department data");
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return Ok("Insert New Department");
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code)
        {
            return Ok("upadte this" + code + "department data");
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok("delete this" + code + "department data");
        }
    }
}
