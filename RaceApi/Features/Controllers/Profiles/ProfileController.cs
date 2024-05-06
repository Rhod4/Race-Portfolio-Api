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
    [AllowAnonymous]
    public async Task<ActionResult<Profile>> Get()
    {
        var profile = await _profileRepository.GetProfile();
        
        return Ok(new
        {
            Success =  profile
        });
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Profile>> Post(Profile profile)
    {
        
        return Ok(new
        {
            Success =  profile
        });
    }
}