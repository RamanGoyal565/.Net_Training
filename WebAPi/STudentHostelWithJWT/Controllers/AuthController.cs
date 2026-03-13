using Microsoft.AspNetCore.Mvc;
using StudentHostelWithJWT.Data;
using StudentHostelWithJWT.DTOs;
using StudentHostelWithJWT.Models;
using StudentHostelWithJWT.Services;

namespace StudentHostelWithJWT.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JwtService _jwt;

    public AuthController(AppDbContext context, JwtService jwt)
    {
        _context = context;
        _jwt = jwt;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password
        };

        _context.Students.Add(student);
        _context.SaveChanges();

        return Ok(student);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var student = _context.Students
            .FirstOrDefault(x =>
                x.Email == dto.Email &&
                x.Password == dto.Password);

        if (student == null)
            return Unauthorized();

        var token = _jwt.GenerateToken(student);

        return Ok(new { token });
    }
}