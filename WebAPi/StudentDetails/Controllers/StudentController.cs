using Microsoft.AspNetCore.Mvc;
using StudentDetails.DTO;
using StudentDetails.Models;

namespace StudentDetails.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();

        // POST: api/student
        [HttpPost("Create")]
        public IActionResult CreateStudent(CreateRequestDTO request)
        {
            Student student = new Student
            {
                Id = request.Id,
                Name = request.Name,
                Age = request.Age,
                Email = request.Email,
            };

            students.Add(student);

            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult UpdateStudent(int id,UpdateRequestDTO request)
        {
            Student student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            student.M1 = request.M1;
            student.M2 = request.M2;
            student.Total = student.M1 + student.M2;
            string grade = "";
            if (student.Total >= 90)
            {
                grade = "A";
            }
            else if (student.Total >= 80)
            {
                grade = "B";
            }
            else if (student.Total >= 70)
            {
                grade = "C";
            }
            else if (student.Total >= 60)
            {
                grade = "D";
            }
            else
            {
                grade = "F";
            }
            student.Grade = grade;
            return Ok();
        }
        [HttpGet]
        public IActionResult GetStudent(int id)
        {
            Student student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            ResponseDTO response = new ResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                Grade = student.Grade,
                M1 = student.M1,
                M2 = student.M2,
                Total = student.Total
            };
            return Ok(response);
        }
    }
}
