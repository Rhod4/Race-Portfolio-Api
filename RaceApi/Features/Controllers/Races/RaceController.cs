using Microsoft.AspNetCore.Mvc;
using RaceApi.Repositories.Races.Interfaces;

namespace RaceApi.Features.Controllers.Races;

[Route("api/[controller]")]
public class RaceController: ControllerBase
{
    private readonly IRaceRepository _raceRepository;

    public RaceController(IRaceRepository raceRepository)
    {
        _raceRepository = raceRepository;
    }

    [HttpGet("Races")]
    public async Task<ActionResult<IEnumerable<Persistence.Models.Race>>> GetRaces() {
        
        var races = await _raceRepository.GetRaces();

        return Ok(new
        {
            Success = races
        });
    }
}