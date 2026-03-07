using Microsoft.AspNetCore.Mvc;
using MVCWithRepo.Models;
using MVCWithRepo.Repositories;

namespace MVCWithRepo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository repo;

        public StudentController(IStudentRepository repository)
        {
            repo = repository;
        }

        [HttpGet("student/all")]
        public IActionResult List()
        {
            var students = repo.GetAllStudents();

            List<string> result = new List<string>();

            foreach (var s in students)
            {
                int total = s.M1 + s.M2;
                result.Add($"{s.Name} Total = {s.M1 + s.M2}");
            }

            return Content(string.Join("\n", result));
        }

        public IActionResult Add()
        {
            Student s = new Student
            {
                
                Name = "Kumar",
                M1 = 75,
                M2 = 80
            };

            repo.AddStudent(s);

            return Content("Student Added");
        }
    }
}
