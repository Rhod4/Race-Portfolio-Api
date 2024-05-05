using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.Profiles.Interfaces;

public interface IProfileRepository
{
    public Task<Profile> GetProfile();
}