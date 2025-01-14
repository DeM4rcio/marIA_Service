using app.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public AuthController( IConfiguration configuration, AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }        


    [HttpPost("login")]
    public IActionResult login([FromBody] User login)
    {
        User user = _context.Users.FirstOrDefault(e => e.Email == login.Email);

        if(user == null)
        {
            return StatusCode(404, "User not found");
        }

        if(login.Email == user.Email && login.Password == user.Password)
        {
            var token = TokenService.GenerateJwtToken(login.Email);
            return Ok(new{Token = token});
        }

        return Unauthorized();

    }
}