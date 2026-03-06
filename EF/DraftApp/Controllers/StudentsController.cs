using Microsoft.AspNetCore.Mvc;
using DraftApp.Models;
using DraftApp.Services;

namespace DraftApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        // LIST + SEARCH
        public async Task<IActionResult> Index(string? q = null)
        {
            var items = await _service.SearchAsync(q);
            ViewBag.querry = q ?? "";
            return View(items);
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var student = await _service.GetAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(student);
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _service.GetAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.StudentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}