using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Tracks.Interfaces;

namespace RaceApi.Repositories.Tracks;

public class TrackRepository: ITrackRepository
{
    private readonly RaceProjectContext _db;

    public TrackRepository(RaceProjectContext db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<Track>> GetTracks()
    {
        return await _db.Track
            .Include(t => t.Game)
            .Select(
                t => new Track
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Game = new Game
                    { 
                        Id = t.Game.Id,
                        Name = t.Game.Name,
                    }
                })
            .ToListAsync();
    }

    public async Task<IEnumerable<Track>> GetTracksByGame(Guid game)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Track>> GetTracksByCountry(Guid countryId, Guid? gameId)
    {
       return await _db.Track.Where(t => t.Location.Id == countryId && (gameId == null || t.GameId == gameId)).ToListAsync();
    }
}