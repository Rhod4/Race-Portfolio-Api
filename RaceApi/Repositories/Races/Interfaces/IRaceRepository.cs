using RaceApi.Models.Dto;
using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.Races.Interfaces;

public interface IRaceRepository
{
    public Task<IEnumerable<RaceDto>> GetRaces(int? total = null); 
    public Task<RaceDto> GetRace(Guid id); 
    public Task AddUserToRaceParticipants(Guid raceId, string userId ,int userRaceNumber, Guid carId); 
    public Task RemoveUserFromRaceParticipants(Guid raceId, string userId); 
    public Task<bool> AlreadyParticipating(Guid raceId, string userId);
    public Task<IEnumerable<RaceParticipantsDto>> GetRaceParticipants(Guid raceId);
}