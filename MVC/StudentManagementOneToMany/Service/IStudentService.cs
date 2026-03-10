using StudentManagementOneToMany.Models;

namespace StudentManagementOneToMany.Service
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
