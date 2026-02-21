using Microsoft.AspNetCore.Mvc;

namespace ControllerToController.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Recieve()
        {
            var message = TempData["Message"];
            return Content(message?.ToString());
        }
    }
}
