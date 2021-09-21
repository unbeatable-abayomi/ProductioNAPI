using System.Collections.Generic;
using System.Threading.Tasks;
using DLO.DBContext;
using DLO.Model;
using Microsoft.EntityFrameworkCore;

namespace DLO.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> InsertAsync(Student student);
        
        Task<List<Student>> GetAllAsync();
        Task <Student> DeleteAsync(string code);
       
        Task <Student> GetAsync(string code);
        Task<Student> UpdateAsync(string code,Student student);
    }



    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> InsertAsync(Student student)
        {
           
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var student = await _dbContext.Students.ToListAsync();
            return student;
        }
        
        public async Task<Student> DeleteAsync(string email)
        {

            var student = await _dbContext.Students.FirstOrDefaultAsync(c => c.Email == email);
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }
        public async Task<Student> GetAsync(string email)
        {

            var student = await _dbContext.Students.FirstOrDefaultAsync(c => c.Email == email);
            return student;
        }
        
        public async Task<Student> UpdateAsync(string email,Student student)
        {

            var findStudent = await _dbContext.Students.FirstOrDefaultAsync(c => c.Email == email);
            findStudent.Name = student.Name;
            _dbContext.Students.Update(findStudent);
            await _dbContext.SaveChangesAsync();
            return findStudent;
        }
    }
}