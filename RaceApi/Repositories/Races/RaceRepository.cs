using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Races.Interfaces;

namespace RaceApi.Repositories.Races;

public class RaceRepository: IRaceRepository
{
    private readonly RaceProjectContext _db;

    public RaceRepository(RaceProjectContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Race>> GetRaces()
    {
        var races = await _db.Race.ToListAsync();

        return races;
    }
}