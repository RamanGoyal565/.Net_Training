using DraftApp.Models;
namespace DraftApp.Services
{
    public interface IStudentService
    {
        Task<List<Student>> SearchAsync(string q = null);
        
    }
}
