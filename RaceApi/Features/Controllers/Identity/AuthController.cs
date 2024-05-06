using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace RaceApi.Features.Controllers.Identity;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
// Example Login Action in your controller

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] string login, string passowrd)
    {
        // Perform authentication based on username and password
        // For simplicity, we'll use a hardcoded check here
        if (login == "admin" && passowrd == "password")
        {
            // Create claims for the authenticated user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login),
                // Add any additional claims here (e.g., roles)
            };

            // Create claims identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Sign in the user
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            // Return a success response
            return Ok(new { Message = "Login successful" });
        }

        // Authentication failed
        return Unauthorized(new { Message = "Invalid username or password" });
    }


    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // Sign out the user
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok("Index");
    }

    [HttpGet("testAuth")]
    [Authorize]
    public async Task<ActionResult> test()
    {
        return Ok("success");
    }
}