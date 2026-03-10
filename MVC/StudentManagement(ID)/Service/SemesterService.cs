using StudentManagement_ID_.Models;
using StudentManagement_ID_.Repository;

namespace StudentManagement_ID_.Service
{
    public class SemesterService:ISemesterService
    {

        private readonly ISemesterRepository _repo;

        public SemesterService(ISemesterRepository repo)
        {
            _repo = repo;
        }

        public List<Semester> GetStudentSemesters(int studentId)
        {
            return _repo.GetByStudentId(studentId);
        }

        public Semester GetSemester(int id)
        {
            return _repo.GetById(id);
        }
        public void AddSemester(Semester semester)
        {
            _repo.Add(semester);
            _repo.Save();
        }

        public void UpdateSemester(Semester semester)
        {
            _repo.Update(semester);
            _repo.Save();
        }
    }
}
