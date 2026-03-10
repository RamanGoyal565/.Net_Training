using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement_ID_.Models;
using StudentManagement_ID_.Service;

namespace StudentManagement_ID_.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISemesterService _semesterService;

        public StudentController(IStudentService studentService,
                                 ISemesterService semesterService)
        {
            _studentService = studentService;
            _semesterService = semesterService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Register(student);
                return RedirectToAction("Login");
            }
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return View(student);
            }
            return View(student);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var student = _studentService.Login(email, password);

            if (student != null)
            {
                HttpContext.Session.SetInt32("StudentId", student.Id);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("StudentId") == null)
            {
                return RedirectToAction("Login");
            }

            int id = (int)HttpContext.Session.GetInt32("StudentId");

            var student = _studentService.GetStudent(id);

            return View(student);
        }

        public IActionResult IdCard()
        {
            if (HttpContext.Session.GetInt32("StudentId") == null)
            {
                return RedirectToAction("Login");
            }

            int id = (int)HttpContext.Session.GetInt32("StudentId");

            var student = _studentService.GetStudent(id);

            return View(student);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Semesters()
        {
            if (HttpContext.Session.GetInt32("StudentId") == null)
                return RedirectToAction("Login");

            int studentId = (int)HttpContext.Session.GetInt32("StudentId");

            var semesters = _semesterService.GetStudentSemesters(studentId);

            return View(semesters);
        }

        public IActionResult EditSemester(int id)
        {
            var semester = _semesterService.GetSemester(id);

            return View(semester);
        }

        [HttpPost]
        public IActionResult EditSemester(Semester semester)
        {
            _semesterService.UpdateSemester(semester);

            return RedirectToAction("Semesters");
        }
        public IActionResult AddSemester()
        {
            if (HttpContext.Session.GetInt32("StudentId") == null)
                return RedirectToAction("Login");

            return View();
        }
        [HttpPost]
        public IActionResult AddSemester(Semester semester)
        {
            int studentId = (int)HttpContext.Session.GetInt32("StudentId");

            semester.StudentId = studentId;

            _semesterService.AddSemester(semester);

            return RedirectToAction("Semesters");
        }
    }
}
