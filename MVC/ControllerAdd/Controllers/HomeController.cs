using ControllerAdd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControllerAdd.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Raman";
            ViewData["CollegeName"] = "LPU";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Square(int a)
        {
            TempData["Number"] = a;
            return RedirectToAction("Square", "Student");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}