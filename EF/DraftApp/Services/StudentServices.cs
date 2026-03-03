using DraftApp.Models;
using DraftApp.Repositories;
namespace DraftApp.Services
{
    public class StudentServices:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Task<List<Student>> SearchAsync(string q = null)
        {
            return _studentRepository.GetAllAsync(q);
        }
    }
}
