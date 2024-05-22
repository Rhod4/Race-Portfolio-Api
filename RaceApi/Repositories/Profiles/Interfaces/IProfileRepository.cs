using Microsoft.AspNetCore.Mvc;
using RaceApi.Models.Dto;
using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.Profiles.Interfaces;

public interface IProfileRepository
{
    public Task<Profile> GetProfileById(string id);

    public Task<ProfileDetailsDto?> AddUserDetailsToDatabase(ProfileDetailsDto profile);
}