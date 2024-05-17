using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.Races.Interfaces;

public interface IRaceRepository
{
    public Task<IEnumerable<Race>> GetRaces(); 
    public Task AddUserAsParticipateInRace(Guid raceId, string userId ,int userRaceNumber); 
}