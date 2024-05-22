using Microsoft.EntityFrameworkCore;
using RaceApi.Models.Dto;
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

    public async Task<Profile> GetProfileById(string id)
    {
         var profile = await _db.Profile.SingleAsync(p => p.Id == id);
         
        return profile;
    }

    public async Task<ProfileDetailsDto?> AddUserDetailsToDatabase(ProfileDetailsDto profile)
    {
        
        var profileToUpdate = await _db.Profile.SingleOrDefaultAsync(p => p.Id == profile.UserId);
        
        if(profileToUpdate != null)
        {
            profileToUpdate.Firstname = profile.Firstname;
            profileToUpdate.Lastname = profile.Lastname;
            
            await _db.SaveChangesAsync();
            
            return new ProfileDetailsDto
            {
                UserId = profileToUpdate.Id,
                Firstname = profileToUpdate.Firstname,
                Lastname = profileToUpdate.Lastname,
                Email = profileToUpdate.Email!
            };
        }
        return null;
    }

}