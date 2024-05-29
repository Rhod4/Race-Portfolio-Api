using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaceApi.Models.Dto;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Tracks.Interfaces;

namespace RaceApi.Repositories.Tracks;

public class TrackRepository: ITrackRepository
{
    private readonly RaceProjectContext _db;
    private IMapper _mapper;

    public TrackRepository(RaceProjectContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
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

    public async Task<IEnumerable<TrackDto>> GetTracksByGame(Guid gameId)
    {
        var tracks = await _db.Track.Where(t => t.GameId == gameId).ToListAsync();

        return tracks.Select(_mapper.Map<TrackDto>);
    }

    public async Task<TrackDto> GetTrackById(Guid trackId)
    {
        var track = await _db.Track
            .SingleAsync(t => t.Id == trackId);

        return _mapper.Map<TrackDto>(track);
    }

    public async Task<IEnumerable<Track>> GetTracksByCountry(Guid countryId, Guid? gameId)
    {
       return await _db.Track.Where(t => t.Location.Id == countryId && (gameId == null || t.GameId == gameId)).ToListAsync();
    }
}