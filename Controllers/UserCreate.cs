// Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;
using AudioEmotionApp.Models;
using AudioEmotionApp.DTOs;
using AudioEmotionApp.Data;

namespace AudioEmotionApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public IActionResult AddUser([FromBody] UserCreateDto dto)
        {
            if (_context.Users.Any(u => u.Username == dto.Username))
            {
                return BadRequest("Username already exists.");
            }

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.Password, // OBS! Hasha i riktig app!
                Role = dto.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "User created successfully!" });
        }
    }
}

