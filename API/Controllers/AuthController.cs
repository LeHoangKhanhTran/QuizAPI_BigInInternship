using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.DTOs;
using QuizAPI.Entities;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly JwtTokenGenerator _tokenGenerator;
    private readonly UserManager<User> _userManager;
    public AuthController(UserManager<User> userManager, JwtTokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        var user = new User { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            return Ok(new { message = "User registered successfully!" });
        }
        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = await _tokenGenerator.GenerateToken(user);
            var cookieOptions = new CookieOptions 
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax
            };
            HttpContext.Response.Cookies.Append("access_token", token,  cookieOptions);
            return Ok(new UserInfoDto(Guid.Parse(user.Id), user.Email, (await _userManager.GetRolesAsync(user)).ToList()));
        }
        return Unauthorized("User not found or password is incorrect.");
    }

    [HttpPost]
    [Route("logout")]
    public async Task<ActionResult> LogOut() {
        var cookieOptions = new CookieOptions 
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Path = "/",
            Expires = DateTime.UtcNow.AddDays(-1)
        };
        Response.Cookies.Append("access_token", "", cookieOptions);
        return Ok(new {message = "User logged out"});
    }
}