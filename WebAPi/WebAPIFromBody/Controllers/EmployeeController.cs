using Microsoft.AspNetCore.Mvc;
namespace WebAPIFromBody.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees=new List<Employee>();
        [HttpPost("add")]
        public IActionResult AddEmployee([FromBody] List<Employee> employees)
        {
            _employees.AddRange(employees);
            string message = "Employees added successfully. Employee details are: \n";
            foreach (var employee in _employees)
            {
                message+=($"Employee Name: {employee.Name}, Employee Salary: {employee.Salary}");
            }
            return Ok(message);
        }
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            if (_employees == null || _employees.Count == 0)
            {
                return NotFound("No employees found.");
            }
            return Ok(_employees);
        }
        [HttpGet("GetTotalSalary")]
        public IActionResult GetTotalEmployeeSalary() {
            if (_employees == null || _employees.Count == 0)
            {
                return NotFound("No employees found.");
            }
            return Ok(_employees.Sum(e=>e.Salary));
        }
    }
}