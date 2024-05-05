using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Profiles.Interfaces;

namespace RaceApi.Repositories.Profiles;

public class ProfileRepository: IProfileRepository
{
    private RaceProjectContext _raceProjectContext;

    public ProfileRepository(RaceProjectContext raceProjectContext)
    {
        _raceProjectContext = raceProjectContext;
    }

    public async Task<Profile> GetProfile()
    {
         var t = await _raceProjectContext.Profile.SingleAsync(p => p.Email == "James@GSnail.com");
        
        var profile = new Profile
        {
            Id = Guid.NewGuid(),
            Firstname = "James",
            Lastname = "Fletcher",
            Email = "JamesFletch@GSnail.com"
        };

        return profile;
    }
}