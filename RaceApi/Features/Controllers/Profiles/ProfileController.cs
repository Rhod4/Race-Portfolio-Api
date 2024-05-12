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
        var test = HttpContext.User.Identity;
        
        var profile = await _profileRepository.GetProfile(test.Name);
        
        return Ok(new
        {
            Success =  profile.Id,
        });
    }
}