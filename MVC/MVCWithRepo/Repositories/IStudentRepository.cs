using MVCWithRepo.Models;

namespace MVCWithRepo.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
    }
}
