using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Profiles.Interfaces;

namespace RaceApi.Repositories.Profiles;

public class ProfileRepository: IProfileRepository
{
    private RaceProjectContext _db;

    public ProfileRepository(RaceProjectContext raceProjectContext)
    {
        _db = raceProjectContext;
    }

    public async Task<Profile> GetProfile(string id)
    {
         var profile = await _db.Profile.SingleAsync(p => p.Id == id);
         
        return profile;
    }

}