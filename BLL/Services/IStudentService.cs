using System.Collections.Generic;
using System.Threading.Tasks;
using DLO.Model;
using DLO.Repositories;

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
           return await _studentRepository.InsertAsync(student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> DeleteAsync(string code)
        {
            return await _studentRepository.DeleteAsync(code);
        }

        public async Task<Student> GetAsync(string code)
        {
            return await _studentRepository.GetAsync(code);
        }

        public async Task<Student> UpdateAsync(string code, Student student)
        {
            return await _studentRepository.UpdateAsync(code, student);
        }
    }
}