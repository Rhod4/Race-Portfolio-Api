using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaceApi.Models.Dto;
using RaceApi.Persistence;
using RaceApi.Repositories.Games.Interfaces;

namespace RaceApi.Repositories.Games;

public class GameRepository: IGameRepository
{
    private readonly RaceProjectContext _db;
    private readonly IMapper _mapper;


    public GameRepository(RaceProjectContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GameDto>> GetGames()
    {
        var games = await _db.Game.ToListAsync();

        var gameDtos = games.Select(game =>
            _mapper.Map<GameDto>(game));

        return gameDtos;
    }
    
    public async Task<IEnumerable<GameDto>> GetGamesWithTracks()
    {
        var games = await _db.Game
            .Include(g => g.Tracks)
            .ToListAsync();

        var gameDtos = games.Select(game =>
            _mapper.Map<GameDto>(game));

        return gameDtos;
    }
}