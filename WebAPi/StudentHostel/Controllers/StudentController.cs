using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentHostel.DTO;
using StudentHostel.Models;

namespace StudentHostel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly CollegeDbContext _context;

        public StudentController(CollegeDbContext context)
        {
            _context = context;
        }

        // CREATE STUDENT
        [HttpPost]
        public IActionResult CreateStudent(StudentCreateDTO dto)
        {
            Student student = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                HostelId = dto.HostelId
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student.StudentId);
        }

        // GET ALL STUDENTS
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students
                .Include(s => s.Hostel)
                .Select(s => new StudentResponseDTO
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    Age = s.Age,
                    RoomNumber = s.Hostel.RoomNumber,
                    Block = s.Hostel.Block
                })
                .ToList();

            return Ok(students);
        }

        // GET STUDENT BY ID
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _context.Students
            .Include(s => s.Hostel)
            .Select(s => new StudentResponseDTO
            {
                StudentId = s.StudentId,
                Name = s.Name,
                Age = s.Age,
                RoomNumber = s.Hostel != null ? s.Hostel.RoomNumber : null,
                Block = s.Hostel != null ? s.Hostel.Block : null
            })
            .ToList();

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // UPDATE STUDENT
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, StudentUpdateDTO dto)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
                return NotFound("Student not found");

            student.Name = dto.Name;
            student.Age = dto.Age;
            student.HostelId = dto.HostelId;

            _context.SaveChanges();

            return Ok("Student updated successfully");
        }

        // DELETE STUDENT
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
                return NotFound("Student not found");

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok("Student deleted successfully");
        }
    }
}