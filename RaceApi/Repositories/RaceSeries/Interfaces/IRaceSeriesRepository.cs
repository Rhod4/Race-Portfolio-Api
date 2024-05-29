using RaceApi.Models.Dto;
using RaceApi.Persistence.Models;

namespace RaceApi.Repositories.RaceSeries.Interfaces;

public interface IRaceSeriesRepository
{
    public Task<RaceSeriesDto> CreateSeries(Persistence.Models.Series series, Race race);
}