using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using RaceApi.Features.Models;
using RaceApi.Repositories.Identity.Interface;

namespace RaceApi.Features.Controllers.Identity;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    // Example Login Action in your controller

    [HttpPost("login")]
    public async Task<IActionResult> Login(Login login)
    {
        var userId = await _authRepository.LoginSuccess(login.Username, login.Password);
        
        if (userId != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userId.ToString()!),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return Ok(new { Message = "Login successful" });
        }

        return Unauthorized(new { Message = "Invalid username or password" });
    }


    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok("Index");
    }


    [HttpGet("test")]
    [Authorize]
    public async Task<ActionResult<dynamic>> Get()
    {
        // var test = HttpContext.User.Identity;
        //
        // var profile = await _profileRepository.GetProfile(test.Name);
        
        return Ok(new
        {
            Success =  "profile.Id",
        });
    }
    
}