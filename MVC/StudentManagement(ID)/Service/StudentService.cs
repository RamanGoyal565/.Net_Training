using StudentManagement_ID_.Models;
using StudentManagement_ID_.Repository;
using StudentManagement_ID_.Service;
namespace StudentManagement_ID_.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public void Register(Student student)
        {
            _repo.Add(student);
            _repo.Save();
        }

        public Student Login(string email, string password)
        {
            var student = _repo.GetByEmail(email);

            if (student != null && student.Password == password)
            {
                return student;
            }

            return null;
        }

        public Student GetStudent(int id)
        {
            return _repo.GetById(id);
        }
    }
}