using StudentManagement_ID_.Models;
namespace StudentManagement_ID_.Repository
{
    public interface ISemesterRepository
    {
        List<Semester> GetByStudentId(int studentId);

        Semester GetById(int id);
        void Add(Semester semester);
        void Update(Semester semester);

        void Save();
    }
}