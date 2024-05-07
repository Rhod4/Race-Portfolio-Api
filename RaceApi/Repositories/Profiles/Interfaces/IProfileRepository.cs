using Microsoft.AspNetCore.Mvc;
using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.Profiles.Interfaces;

public interface IProfileRepository
{
    public Task<Profile> GetProfile(string id);
}