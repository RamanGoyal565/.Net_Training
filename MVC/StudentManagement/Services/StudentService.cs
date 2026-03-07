using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
namespace StudentManagement.Services
{
    public class StudentService
    {
        private readonly StudentManagementContext _context;
        public StudentService(StudentManagementContext context)
        {
            _context = context;
        }
        public List<Student> GetAllStudents()
        {
            // Logic to retrieve all students from the database
            return _context.Students.Include(s=>s.AssignedRoom).ToList();
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}
