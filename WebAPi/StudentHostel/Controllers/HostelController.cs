using Microsoft.AspNetCore.Mvc;
using StudentHostel.Models;
using StudentHostel.DTO;
using Microsoft.EntityFrameworkCore;

namespace StudentHostel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostelController : ControllerBase
    {
        private readonly CollegeDbContext _context;

        public HostelController(CollegeDbContext context)
        {
            _context = context;
        }

        // GET ALL HOSTELS
        [HttpGet]
        public IActionResult GetHostels()
        {
            var hostels = _context.Hostels.Select(s => new HostelResponseDTO
            {
                 HostelId= s.HostelId,
                RoomNumber = s.RoomNumber,
                Block = s.Block
            }).ToList();

            return Ok(hostels);
        }

        // GET HOSTEL BY ID
        [HttpGet("{id}")]
        public IActionResult GetHostel(int id)
        {
            var hostel = _context.Hostels.FirstOrDefault(h => h.HostelId == id);

            if (hostel == null)
                return NotFound("Hostel not found");

            return Ok(hostel);
        }
    }
}