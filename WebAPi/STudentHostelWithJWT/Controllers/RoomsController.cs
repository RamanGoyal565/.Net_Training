using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentHostelWithJWT.Data;
using StudentHostelWithJWT.Models;
using StudentHostelWithJWT.DTOs;
namespace StudentHostelWithJWT.Controllers;

[ApiController]
[Route("api/rooms")]
[Authorize(Roles = "Admin")]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Rooms.ToList());
    }

    [HttpPost]
    public IActionResult Create(CreateRoomDto dto)
    {
        var room = new Room
        {
            RoomNumber = dto.RoomNumber
        };

        _context.Rooms.Add(room);
        _context.SaveChanges();

        return Ok(room);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Room room)
    {
        var existing = _context.Rooms.Find(id);

        existing.RoomNumber = room.RoomNumber;

        _context.SaveChanges();

        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var room = _context.Rooms.Find(id);

        _context.Rooms.Remove(room);
        _context.SaveChanges();

        return Ok();
    }
}