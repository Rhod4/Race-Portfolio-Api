using RaceApi.Models.Dto;
using RaceApi.Models.Requests;
using RaceApi.Persistence.Models;

namespace RaceApi.Services.Interfaces;

public interface ICreateRaceService
{
    public Task<RaceDto> CreateCompleteRaceByGame(CreateRaceRequest createRaceRequest, Profile profile);
    public Task<RaceDto> EditCompleteRaceByGame(CreateRaceRequest createRaceRequest, Profile profile);
}