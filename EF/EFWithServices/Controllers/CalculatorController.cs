using Microsoft.AspNetCore.Mvc;
using EFWithServices.Services;

namespace EFWithServices.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calcualtor;
        public CalculatorController(CalculatorService calculator)
        {
            _calcualtor = calculator;
        }
        public IActionResult Add(int a, int b)
        {
            var result = _calcualtor.Add(a,b);
            return Content("Result = "+result);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}