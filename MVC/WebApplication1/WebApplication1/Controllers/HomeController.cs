using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Square(int? number)
        {
            if (number == null)
                return Content("Please provide a number");
            return View(number.Value);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Student()
        {
            var s = new { Name = "Raman", Id = 12 };
            return Json(s);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}