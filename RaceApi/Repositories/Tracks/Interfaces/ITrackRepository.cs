using RaceApi.Models.Dto;

namespace RaceApi.Repositories.Tracks.Interfaces;

public interface ITrackRepository
{
    public Task<IEnumerable<Persistence.Models.Track>> GetTracks();
    public Task<IEnumerable<TrackDto>> GetTracksByGame(Guid gameId);
    public Task<IEnumerable<Persistence.Models.Track>> GetTracksByCountry(Guid country, Guid? game);
}