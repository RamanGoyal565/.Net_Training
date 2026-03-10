using StudentManagementOneToMany.Models;
using StudentManagementOneToMany.Repository;

namespace StudentManagementOneToMany.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Student> GetStudents()
        {
            return repository.GetAll();
        }

        public Student GetStudent(int id)
        {
            return repository.GetById(id);
        }

        public void AddStudent(Student student)
        {
            repository.Insert(student);
            repository.Save();
        }

        public void UpdateStudent(Student student)
        {
            repository.Update(student);
            repository.Save();
        }

        public void DeleteStudent(int id)
        {
            repository.Delete(id);
            repository.Save();
        }
    }
}
