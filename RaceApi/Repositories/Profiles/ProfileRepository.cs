using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaceApi.Models.Dto;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Profiles.Interfaces;

namespace RaceApi.Repositories.Profiles;

public class ProfileRepository: IProfileRepository
{
    private RaceProjectContext _db;
    private IMapper _mapper;

    public ProfileRepository(RaceProjectContext raceProjectContext, IMapper mapper)
    {
        _db = raceProjectContext;
        _mapper = mapper;
    }

    public async Task<ProfileDto> GetProfileById(string id)
    {
         var profile = await _db.Profile.SingleAsync(p => p.Id == id);

         return _mapper.Map<ProfileDto>(profile);
    }

    public async Task<ProfileDto?> AddUserDetailsToDatabase(ProfileDetailsDto profile)
    {
        
        var profileToUpdate = await _db.Profile.SingleOrDefaultAsync(p => p.Id == profile.UserId);
        
        if(profileToUpdate != null)
        {
            profileToUpdate.Firstname = profile.Firstname;
            profileToUpdate.Lastname = profile.Lastname;
            
            await _db.SaveChangesAsync();
            
            return _mapper.Map<ProfileDto>(profileToUpdate);
        }
        return null;
    }

}