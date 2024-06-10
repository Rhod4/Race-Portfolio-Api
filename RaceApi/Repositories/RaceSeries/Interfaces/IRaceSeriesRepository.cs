using RaceApi.Models.Dto;
using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.RaceSeries.Interfaces;

public interface IRaceSeriesRepository
{
    public Task<RaceSeriesDto> CreateSeries(Persistence.Models.Series series, Race race);
    public Task<RaceSeriesDto> UpdateSeries(Persistence.Models.Series series, Race race);
    public Task<RaceSeriesDto> RemoveSeries(Persistence.Models.Series series, Race race);
}