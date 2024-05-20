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

    public async Task<IEnumerable<Race>> GetRaces(int? total)
    {
        var races = await _db.Race.Include(r => r.Game)
            .ToListAsync();

        
        if (total.HasValue && races.Count > total)
        {
            races = races.Take(total.Value).ToList();
        }
        
        return races;
    }

    public async Task<Race> GetRace(Guid id)
    {
        return await _db.Race
            .Include(r => r.Game)
            .Include(r => r.RaceParticipants)
                .ThenInclude(r => r.Profile)
            .Include(r => r.RaceMarshel)
            .SingleAsync(race => race.Id == id);
    }

    public async Task AddUserToRaceParticipants(Guid raceId, string userId ,int userRaceNumber)
    {
        await _db.RaceParticipants.AddAsync(new RaceParticipants
        {
            RaceId = raceId,
            ProfileId = userId,
            UserRaceNumber = userRaceNumber
        });
        await _db.SaveChangesAsync();
    }

    public async Task RemoveUserFromRaceParticipants(Guid raceId, string userId)
    {
       var participantsToRemove = await _db.RaceParticipants.FirstAsync(participants =>
            participants.RaceId == raceId && participants.ProfileId == userId);
       
       _db.RaceParticipants.Remove(participantsToRemove);
       
       await _db.SaveChangesAsync();
    }

    public async Task<bool> AlreadyParticipating(Guid raceId, string userId)
    {
        return await _db.RaceParticipants.AnyAsync(rp => rp.RaceId == raceId && rp.ProfileId == userId);
    }

    public async Task<IEnumerable<RaceParticipants>> GetRaceParticipants(Guid raceId)
    {
        return await _db.RaceParticipants
            .Include(rp => rp.Profile)
            .Include(rp => rp.Car)
            .Include(rp => rp.RaceId)
            .Where(rp => rp.RaceId == raceId)
            .ToListAsync();
    }
}