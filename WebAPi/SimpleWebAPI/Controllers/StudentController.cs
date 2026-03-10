using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        [HttpGet("getstudents")]
        public IActionResult GetStudents()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Marks = 85 },
                new Student { Id = 2, Name = "Bob", Marks = 90 },
                new Student { Id = 3, Name = "Charlie", Marks = 78 }
            };
            return Ok(students);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet("add")]
        public IActionResult Add(int a, int b, int c)
        {
            if (a < 100 && b < 100 && c < 100 && a > 0 && b > 0 && c > 0)
            {

                int sum = a + b + c;
                return Ok(sum);
            }
            return BadRequest("Value must be between 1 and 100");
        }
        
    }
}
