using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaceApi.Models.Dto;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Races.Interfaces;

namespace RaceApi.Repositories.Races;

public class RaceRepository: IRaceRepository
{
    private readonly RaceProjectContext _db;
    private readonly IMapper _mapper;

    public RaceRepository(RaceProjectContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RaceDto>> GetRaces(int? total)
    {
        var races = await _db.Race.Include(r => r.Game)
            .ToListAsync();

        
        if (total.HasValue && races.Count > total)
        {
            races = races.Take(total.Value).ToList();
        }

        var raceDtos = races.Select(race =>
            _mapper.Map<RaceDto>(race));
        
        return raceDtos;
    }

    public async Task<RaceDto> GetRace(Guid id)
    {
        var race = await _db.Race
            .Include(r => r.Game)
            .Include(r => r.RaceParticipants)
                .ThenInclude(r => r.Profile)
            .Include(r => r.RaceMarshel)
            .SingleAsync(race => race.Id == id);

        return _mapper.Map<RaceDto>(race);
    }

    public async Task AddUserToRaceParticipants(Guid raceId, string userId ,int userRaceNumber, Guid carId)
    {
        var car = await _db.Cars.SingleAsync(car => car.Id == carId);
        
        await _db.RaceParticipants.AddAsync(new RaceParticipants
        {
            RaceId = raceId,
            ProfileId = userId,
            UserRaceNumber = userRaceNumber,
            Car = car
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

    public async Task<IEnumerable<RaceParticipantsDto>> GetRaceParticipants(Guid raceId)
    {
        var raceParticipants = await _db.RaceParticipants
            .Include(rp => rp.Profile)
            .Include(rp => rp.Car)
            .Where(rp => rp.Race.Id == raceId)
            .ToListAsync();

        return raceParticipants.Select(_mapper.Map<RaceParticipantsDto>);
    }
}