using EFCodeFirst.Data;
using EFCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;

namespace EFCodeFirst.Controllers
{
    public class Student1Controller : Controller
    {
        private readonly StudentManagementContext _context;

        public Student1Controller(StudentManagementContext context)
        {
            _context = context;
        }


        public IActionResult Create(string name, float age, string city)
        {
            var student = new Student
            {
                Name = name,
                Age = age,
                City = city
            };

            _context.Students.Add(student);
            _context.SaveChanges();



            return Content("Student Created Successfully");
        }
        public IActionResult All()
        {
            var students = _context.Students.ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var s in students)
            {
                sb.Append($"{s.Id} - {s.Name} - {s.Age} - {s.City} <br>");
            }

            return Content(sb.ToString(), "text/html");
        }


        //Students/Details/1
        public IActionResult Details(int id)
        {
            var s = _context.Students.Find(id);

            if (s == null)
                return Content("Student not found");

            return Content($"{s.Id} - {s.Name} - {s.Age} - {s.City}");
        }
        public IActionResult Edit(int id, string name, float age, string city)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return Content("Student not found");

            student.Name = name;
            student.Age = age;
            student.City = city;

            _context.SaveChanges();

            return Content("Student Updated Successfully");
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return Content("Student not found");

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Content("Student Deleted Successfully");
        }
    }
}