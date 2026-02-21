using Microsoft.AspNetCore.Mvc;
using WebApplication_With_ADO.NET.Data;

namespace WebApplication_With_ADO.NET.Controllers
{
    public class StudentController : Controller
    {
       private readonly StudentRepository _repo;

        public StudentController(StudentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult GetStudent()
        {
            var students = _repo.GetAllStudents();
            foreach (var i in students)
                i.Square = Math.Pow((double)i.Age, 2);
            return View(students);
        }
    }
}
