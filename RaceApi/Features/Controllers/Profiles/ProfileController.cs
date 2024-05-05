using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Profiles;

namespace RaceApi.Features.Controllers.Profiles;


[Route("api/[controller]")]
//[Authorize]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly ProfileRepository _profileRepository;

    public ProfileController(ProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    [HttpGet("Get")]
    [AllowAnonymous]
    public async Task<ActionResult<Profile>> Get()
    {
        var profile = await _profileRepository.GetProfile();
        
        return Ok(profile);
    }
}