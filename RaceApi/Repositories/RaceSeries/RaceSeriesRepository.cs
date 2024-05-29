using RaceApi.Models.Dto;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.RaceSeries.Interfaces;

namespace RaceApi.Repositories.RaceSeries;

public class RaceSeriesRepository: IRaceSeriesRepository
{
    public async Task<RaceSeriesDto> CreateSeries(Persistence.Models.Series series, Race race)
    {
        throw new NotImplementedException();
    }
}