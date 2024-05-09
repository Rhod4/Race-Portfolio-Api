using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Profiles.Interfaces;

namespace RaceApi.Features.Controllers.Profiles;


[Route("api/[controller]")]
//[Authorize]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IProfileRepository _profileRepository;

    public ProfileController(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    [HttpGet("test")]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
        var user = HttpContext.User;
        var test = HttpContext.User.Identity;
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
         
        
        var profile = await _profileRepository.GetProfile(userId);
        
        return Ok(new
        {
            Success =  profile,
            User = user,
            UserId = userId
        });
    }
}