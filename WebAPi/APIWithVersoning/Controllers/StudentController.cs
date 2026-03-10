using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
namespace APIWithVersoning.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/student")]
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Version = "V1",Students=new List<string> { "Student1", "Student2", "Student3" } });
        }
    }
}
