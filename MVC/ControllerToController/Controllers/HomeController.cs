using ControllerToController.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControllerToController.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Send()
        {
            TempData["Message"] = "Hello from HomeController!";
            return RedirectToAction("Recieve", "Student");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
