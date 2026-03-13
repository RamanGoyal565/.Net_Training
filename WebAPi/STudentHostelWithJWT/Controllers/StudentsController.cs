using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentHostelWithJWT.Data;
using StudentHostelWithJWT.DTOs;
using StudentHostelWithJWT.Models;
using System.Security.Claims;

namespace StudentHostelWithJWT.Controllers;

[ApiController]
[Route("api/students")]
[Authorize]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _context.Students
            .Include(s => s.Room)
            .Select(s => new StudentWithRoomDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Role = s.Role,
                RoomId = s.RoomId,
                RoomNumber = s.Room != null ? s.Room.RoomNumber : null
            })
            .ToList();

        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var userId = int.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier));

        var role = User.FindFirstValue(ClaimTypes.Role);

        if (role != "Admin" && userId != id)
            return Forbid();

        var student = _context.Students
            .Include(s => s.Room)
            .Where(s => s.Id == id)
            .Select(s => new StudentWithRoomDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Role = s.Role,
                RoomId = s.RoomId,
                RoomNumber = s.Room != null ? s.Room.RoomNumber : null
            })
            .FirstOrDefault();

        return Ok(student);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult Create(CreateStudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            RoomId = dto.RoomId
        };

        _context.Students.Add(student);
        _context.SaveChanges();

        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CreateStudentDto dto)
    {
        var userId = int.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier));

        var role = User.FindFirstValue(ClaimTypes.Role);

        if (role != "Admin" && userId != id)
            return Forbid();

        var student = _context.Students.Find(id);

        student.Name = dto.Name;
        student.Email = dto.Email;
        student.RoomId = dto.RoomId;

        _context.SaveChanges();

        return Ok(student);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);

        _context.Students.Remove(student);
        _context.SaveChanges();

        return Ok();
    }
}