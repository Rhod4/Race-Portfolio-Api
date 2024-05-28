using RaceApi.Models.Dto;
using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.Games.Interfaces;

public interface IGameRepository
{
    public Task<IEnumerable<GameDto>> GetGames();
    public Task<IEnumerable<GameDto>> GetGamesWithTracks();

}