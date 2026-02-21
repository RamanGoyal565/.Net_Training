using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_Error.Models;

namespace WebApplication_Error.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int x = 10;
            int y = 0;
            int res = x / y;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        public IActionResult Error()
        {
            return View();
        }
    }
}
