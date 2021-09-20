using DLO.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLO.Repositories;

namespace API.Controllers
{
    //DRY Dont repeat yourself
    //[ApiVersion("1.0")]
    //[ApiController]
    //[Route("api/v{version:apiVersion}/[controller]")]


    //[ApiController]
    //[Route("api/[controller]")]
    public class StudentController : MainApiController
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentRepository.GetAllAsync());
        }

        [HttpGet("{email}")]

        public async Task <IActionResult> GetAStudent(string email)
        {
            return Ok(await _studentRepository.GetAsync(email));
        }


        [HttpPost]

        public async Task <IActionResult> Insert (Student student)
        {
            return Ok(await _studentRepository.InsertAsync(student));
        }

        //GET
        [HttpPut("{email}")]
        public async Task <IActionResult> Update(string email, Student student)
        {
            return Ok(await _studentRepository.UpdateAsync(email,student));
        }

        [HttpDelete("{email}")]

        public async  Task <IActionResult> Delete(string email)
        {
            return Ok(await _studentRepository.DeleteAsync(email));
        }
        
        /*[HttpGet]
        public IActionResult GetAll()
        {
            return Ok(StudentStatic.GetAllStudents());
        }

        [HttpGet("{email}")]

        public IActionResult GetAStudent(string email)
        {
            return Ok(StudentStatic.GetAStudent(email));
        }


        [HttpPost]

        public IActionResult Insert (Student student)
        {
            return Ok(StudentStatic.InsertStudent(student));
        }

        //GET
        [HttpPut("{email}")]
        public IActionResult Update(string email, Student student)
        {
            return Ok(StudentStatic.UpdateStudent(email, student));
        }

       [HttpDelete("{email}")]

       public IActionResult Delete(string email)
        {
            return Ok(StudentStatic.DeleteStudent(email));
        }*/






        public static class StudentStatic
        {
            public static List<Student> AllStudents { get; set; } = new List<Student>();

            public static Student InsertStudent (Student student)
            {
                AllStudents.Add(student);
                return student;
            }


            public static List<Student> GetAllStudents()
            {
                return AllStudents;
            }

            public static Student GetAStudent(string email)
            {
               return AllStudents.FirstOrDefault(x => x.Email == email);
            }

            public static Student UpdateStudent(string email, Student student)
            {
                Student result = new Student();
                foreach(var aStudent in AllStudents)
                {
                    if (email == aStudent.Email)
                    {
                        aStudent.Name = student.Name;
                        result = aStudent;
                    }
                }

                return result;
            }


            public static Student DeleteStudent(string email)
            {
               var student = AllStudents.FirstOrDefault(s => s.Email == email);
                AllStudents = AllStudents.Where(s => s.Email != student.Email).ToList();

                return student;

            }

        }


       
    }
}
