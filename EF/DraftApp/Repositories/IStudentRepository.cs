using DraftApp.Models;
namespace DraftApp.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(string q=null);

    }
}
