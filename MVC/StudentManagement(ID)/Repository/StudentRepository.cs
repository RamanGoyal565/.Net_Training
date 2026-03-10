using StudentManagement_ID_.Data;
using StudentManagement_ID_.Models;
using Microsoft.EntityFrameworkCore;
namespace StudentManagement_ID_.Repository
{
    
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Student GetByEmail(string email)
        {
            return _context.Students.FirstOrDefault(s => s.Email == email);
        }

        public Student GetById(int id)
        {
            return _context.Students
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
