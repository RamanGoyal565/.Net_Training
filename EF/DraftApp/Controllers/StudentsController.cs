using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        // GET: Students
        public async Task<IActionResult> Index(string q=null)
        {
            var items = await _service.SearchAsync(q);
            ViewBag.querry = q ?? "";
            return View(items);
        }
    }
}
