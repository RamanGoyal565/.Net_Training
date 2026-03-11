using Microsoft.AspNetCore.Mvc;
using JWTAPI.Services;
using JWTAPI.DTO;
namespace JWTAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly JWTTokenService _tokenService;
        public AuthController(JWTTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {

            if (request.Username == "admin" && request.Password == "123")
            {
                var token = _tokenService.GenerateToken(request.Username);

                return Ok(new LoginResponse { Token = token });
            }

            return Unauthorized();
        }
    }
}
