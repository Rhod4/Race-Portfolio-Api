using RaceApi.Models.Dto;

namespace RaceApi.Repositories.Series.Interfaces;

public interface ISeriesRepository
{
    public Task<IEnumerable<SeriesDto>> GetSeries();
    public Task<SeriesDto> GetSingleSeriesById(Guid id);
    public Task<IEnumerable<SeriesDto>> GetSeriesByGame(Guid gameId);
    public Task<IEnumerable<SeriesDto>> GetSeriesAndCarsByGame(Guid gameId);
    
}