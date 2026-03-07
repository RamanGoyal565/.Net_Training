using MVCWithRepo.Models;
namespace MVCWithRepo.Repositories
{
    public class ListStudentRepository: IStudentRepository
    {
        private List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "John", M1 = 85, M2 = 90 },
            new Student { Id = 2, Name = "Jane", M1 = 78, M2 = 88 },
        };
        public List<Student> GetAllStudents()
        {
            return students;
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
}
