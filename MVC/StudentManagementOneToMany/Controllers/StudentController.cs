using Microsoft.AspNetCore.Mvc;
using StudentManagementOneToMany.Models;
using StudentManagementOneToMany.Service;

namespace StudentManagementOneToMany.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var students = service.GetStudents();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            service.AddStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = service.GetStudent(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            service.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            service.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}