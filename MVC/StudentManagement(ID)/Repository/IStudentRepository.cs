using StudentManagement_ID_.Models;

namespace StudentManagement_ID_.Repository
{
    public interface IStudentRepository
    {
        Student GetByEmail(string email);
        Student GetById(int id);
        void Add(Student student);
        void Save();
    }
}
