using StudentManagement_ID_.Models;

namespace StudentManagement_ID_.Service
{
    public interface IStudentService
    {
        void Register(Student student);
        Student Login(string email, string password);
        Student GetStudent(int id);
    }
}
