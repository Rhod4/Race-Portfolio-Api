using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.Races.Interfaces;

public interface IRaceRepository
{
    public Task<IEnumerable<Race>> GetRaces(int? total = null); 
    public Task<Race> GetRace(Guid id); 
    public Task AddUserToRaceParticipants(Guid raceId, string userId ,int userRaceNumber); 
    public Task RemoveUserFromRaceParticipants(Guid raceId, string userId); 
    public Task<bool> AlreadyParticipating(Guid raceId, string userId);
}