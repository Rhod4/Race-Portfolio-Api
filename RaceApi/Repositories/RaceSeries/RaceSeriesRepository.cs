using Microsoft.EntityFrameworkCore;
using RaceApi.Models.Dto;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.RaceSeries.Interfaces;

namespace RaceApi.Repositories.RaceSeries;

public class RaceSeriesRepository : IRaceSeriesRepository
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

    public async Task<RaceSeriesDto> UpdateSeries(Persistence.Models.Series series, Race race)
    {
        var raceSeriesFromDb = await _db.RaceSeries.Where(rs => rs.RaceId == race.Id).ToListAsync();

        var existingRaceSeries = raceSeriesFromDb.FirstOrDefault(rs => rs.SeriesId == series.Id);

        if (existingRaceSeries != null && existingRaceSeries.RaceId == race.Id &&
            existingRaceSeries.SeriesId == series.Id)
            return new RaceSeriesDto();

        _db.RaceSeries.RemoveRange(raceSeriesFromDb.Where(rs => rs.SeriesId != series.Id));

        var newRaceSeries = new Persistence.Models.RaceSeries
        {
            RaceId = race.Id,
            SeriesId = series.Id
        };
        await _db.RaceSeries.AddAsync(newRaceSeries);


        await _db.SaveChangesAsync();

        return new RaceSeriesDto();
    }

    public async Task<RaceSeriesDto> RemoveSeries(Persistence.Models.Series series, Race race)
    {
        var raceSeriesFromDb = await _db.RaceSeries.Where(rs => rs.RaceId == race.Id).ToListAsync();

        _db.RaceSeries.RemoveRange(raceSeriesFromDb);

        await _db.SaveChangesAsync();

        return new RaceSeriesDto();
    }
}