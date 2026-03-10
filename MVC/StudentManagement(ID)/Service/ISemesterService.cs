using StudentManagement_ID_.Models;

namespace StudentManagement_ID_.Service
{
    public interface ISemesterService
    {
        List<Semester> GetStudentSemesters(int studentId);

        Semester GetSemester(int id);
        void AddSemester(Semester semester);
        void UpdateSemester(Semester semester);
    }
}
