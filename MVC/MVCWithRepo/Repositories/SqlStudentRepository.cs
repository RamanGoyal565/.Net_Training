using MVCWithRepo.Data;
using MVCWithRepo.Models;
namespace MVCWithRepo.Repositories
{
    public class SqlStudentRepository: IStudentRepository
    {
        private readonly AppDbContext _context;
        public SqlStudentRepository(AppDbContext db)
        {
            _context = db;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}
