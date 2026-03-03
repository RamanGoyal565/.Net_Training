using EmployeeAppl.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeAppl.Data;
namespace EmployeeAppl.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDAL _dal;
        public EmployeeController(EmployeeDAL dal)
        {
            _dal = dal;
        }

        public IActionResult Index()
        {
            var employees = _dal.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _dal.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _dal.GetAllEmployees()
                               .FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _dal.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _dal.GetAllEmployees()
                               .FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dal.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
