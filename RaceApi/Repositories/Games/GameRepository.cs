using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Games.Interfaces;

namespace RaceApi.Repositories.Games;

public class GameRepository: IGameRepository
{
    private readonly RaceProjectContext _db;

    public GameRepository(RaceProjectContext db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<Game>> GetGames()
    {
        return await _db.Game.ToListAsync();
    }
}