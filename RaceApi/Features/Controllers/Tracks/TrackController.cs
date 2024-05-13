using Microsoft.AspNetCore.Mvc;
using RaceApi.Repositories.Tracks.Interfaces;

namespace RaceApi.Features.Controllers.Tracks;

[Route("api/[controller]")]
public class TrackController: ControllerBase
{
    private readonly ITrackRepository _trackRepository;
    
    public TrackController(ITrackRepository trackRepository)
    {
        _trackRepository = trackRepository;
    }
    
    [HttpGet("AllTracks")]
    public async Task<ActionResult<IEnumerable<Persistence.Models.Track>>> GetTracks()
    {
      var tracks = await _trackRepository.GetTracks();

      return Ok(new
      {
          Success = tracks
      });
    }
    
    [HttpGet("AllTracksByCountry")]
    public async Task<ActionResult<IEnumerable<Persistence.Models.Track>>> GetTracksByCountry(Guid country, Guid? game)
    {
        var tracks = await _trackRepository.GetTracksByCountry(country, game);

        return Ok(new { Success = tracks });
    }
}