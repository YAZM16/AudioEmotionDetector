// AuthController.cs
using AudioEmotionApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AudioEmotionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        // Injektera JwtTokenGenerator i konstruktorn
        public AuthController(IConfiguration config)
        {
            _jwtTokenGenerator = new JwtTokenGenerator(config);
        }

        // Exempel på login-metod där du skickar användarnamn och får en token
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Verifiera användarnamn och lösenord här (du måste ha en autentisering)
            if (model.Username == "test" && model.Password == "password") // Exempel, ersätt med riktig autentisering
            {
                var token = _jwtTokenGenerator.GenerateToken(model.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}