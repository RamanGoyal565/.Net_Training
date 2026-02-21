using Microsoft.AspNetCore.Mvc;

namespace ControllerAdd.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Square()
        {
            var num = TempData["Number"] as int? ?? 0;
            return Content(Math.Pow(num, 2).ToString());
        }
    }
}