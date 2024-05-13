using Microsoft.AspNetCore.Mvc;
using RaceApi.Repositories.Games.Interfaces;

namespace RaceApi.Features.Controllers.Game;

[Route("api/[controller]")]
public class GameController: ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public GameController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpGet("GetGames")]
    public async Task<ActionResult<IEnumerable<Persistence.Models.Race>>> GetGames()
    {
        var games = await _gameRepository.GetGames();
        
        return Ok(new {Success = games});
    }
}