using RaceApi.Models.Dto;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.RaceSeries.Interfaces;

namespace RaceApi.Repositories.RaceSeries;

public class RaceSeriesRepository: IRaceSeriesRepository
{
    private RaceProjectContext _db;

    public RaceSeriesRepository(RaceProjectContext db)
    {
        _db = db;
    }

    public async Task<RaceSeriesDto> CreateSeries(Persistence.Models.Series series, Race race)
    {
        var raceSeries = new Persistence.Models.RaceSeries
        {
            SeriesId = series.Id,
            RaceId = race.Id
        };
        
        await _db.RaceSeries.AddAsync(raceSeries);
        
        await _db.SaveChangesAsync();

        return new RaceSeriesDto();
    }
}