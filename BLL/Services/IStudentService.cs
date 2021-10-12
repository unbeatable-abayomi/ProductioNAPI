using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DLO.Model;
using DLO.Repositories;
using Utility.Exceptions;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<Student> InsertAsync(Student student);
        
        Task<List<Student>> GetAllAsync();
        Task <Student> DeleteAsync(string code);
       
        Task <Student> GetAsync(string code);
        Task<Student> UpdateAsync(string code,Student student);
    }



    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public async Task<Student> InsertAsync(Student student)
        {
            await _studentRepository.CreateAsync(student);
            if (await _studentRepository.SaveCompletedAsync())
            {
                return student;
            }

            throw new ApplicationValidationException("Insert has some problem");
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetList();
        }

        public async Task<Student> DeleteAsync(string email)
        {
            var dbStudent = await _studentRepository.FindSingleAsync(x => x.Email == email);
            if (dbStudent == null)
            {
                throw new ApplicationValidationException("student not found");
            }

            _studentRepository.Delete(dbStudent);
            if (await _studentRepository.SaveCompletedAsync())
            {
                return dbStudent;
            }
            throw new ApplicationValidationException("delete has some issues");
        }

        public async Task<Student> GetAsync(string email)
        {
           return  await _studentRepository.FindSingleAsync(x => x.Email == email);
        }

        public async Task<Student> UpdateAsync(string email, Student student)
        {
            var dbStudent = await _studentRepository.FindSingleAsync(x => x.Email == email);
            if (dbStudent == null)
            {
                throw new ApplicationValidationException("student not found");
            }

            dbStudent.Name = student.Name;
            _studentRepository.Update(dbStudent);
            if (await _studentRepository.SaveCompletedAsync())
            {
                return dbStudent;
            }
            throw new ApplicationValidationException("Update has some issues");
        }
    }
}