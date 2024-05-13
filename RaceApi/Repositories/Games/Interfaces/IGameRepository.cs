using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.Games.Interfaces;

public interface IGameRepository
{
    public Task<IEnumerable<Game>> GetGames();

}