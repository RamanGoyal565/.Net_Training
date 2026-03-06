using DraftApp.Models;
using DraftApp.Repositories;

namespace DraftApp.Services
{
    public class StudentServices : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<List<Student>> SearchAsync(string? q = null)
        {
            return _studentRepository.GetAllAsync(q);
        }

        public Task<Student?> GetAsync(int id)
        {
            return _studentRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Student student)
        {
            student.CreatedAt = DateTime.UtcNow;

            if (student.JoinDate == default)
                student.JoinDate = DateOnly.FromDateTime(DateTime.Today);

            await _studentRepository.AddAsync(student);
        }

        public Task UpdateAsync(Student student)
        {
            return _studentRepository.UpdateAsync(student);
        }

        public Task DeleteAsync(int id)
        {
            return _studentRepository.DeleteAsync(id);
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _studentRepository.ExistsAsync(id);
        }
    }
}