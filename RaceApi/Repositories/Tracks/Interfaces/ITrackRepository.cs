namespace RaceApi.Repositories.Tracks.Interfaces;

public interface ITrackRepository
{
    public Task<IEnumerable<Persistence.Models.Track>> GetTracks();
    public Task<IEnumerable<Persistence.Models.Track>> GetTracksByGame(Guid game);
    public Task<IEnumerable<Persistence.Models.Track>> GetTracksByCountry(Guid country, Guid? game);
}