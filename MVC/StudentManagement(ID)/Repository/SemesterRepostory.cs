using StudentManagement_ID_.Data;
using StudentManagement_ID_.Models;
namespace StudentManagement_ID_.Repository
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly AppDbContext _context;

        public SemesterRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Semester> GetByStudentId(int studentId)
        {
            return _context.Semesters
                .Where(s => s.StudentId == studentId)
                .ToList();
        }

        public Semester GetById(int id)
        {
            return _context.Semesters.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Semester semester)
        {
            _context.Semesters.Update(semester);
        }
        public void Add(Semester semester)
        {
            _context.Semesters.Add(semester);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}