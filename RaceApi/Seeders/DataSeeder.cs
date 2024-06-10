using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;
using RaceApi.Seeders.Cars;
using RaceApi.Seeders.Game;
using RaceApi.Seeders.GameCars;
using RaceApi.Seeders.Location;
using RaceApi.Seeders.Profile;
using RaceApi.Seeders.Race;
using RaceApi.Seeders.RaceParticipants;
using RaceApi.Seeders.RaceSeries;
using RaceApi.Seeders.Series;
using RaceApi.Seeders.Track;

namespace RaceApi.Seeders;

public class DataSeeder
{
    private readonly RaceProjectContext _db;

    public DataSeeder(RaceProjectContext db)
    {
        _db = db;
    }

    public async Task SeedTestDataAsync()
    {
        if(!_db.Profile.Any())
        {
            await ProfileSeeder.Seed(_db);
        }
        if(!_db.Location.Any())
        {
            await LocationSeeder.Seed(_db);
        }
        if(!_db.Game.Any())
        {
            await GameSeeder.Seed(_db);
        }
        var t = await _db.Game.ToListAsync();
        if(!_db.Track.Any())
        {
            await TracksSeeder.Seed(_db);
        }
        if(!_db.Race.Any())
        {
            await RaceSeeder.Seed(_db);
        }
        if(!_db.Series.Any())
        {
            await SeriesSeeder.Seed(_db);
        }
        if(!_db.Cars.Any())
        {
            await CarsSeeder.Seed(_db);
        }
        if(!_db.GameCars.Any())
        {
            await GameCarSeeder.Seed(_db);
        }
        if(!_db.RaceSeries.Any())
        {
            await RaceSeriesSeeder.Seed(_db);
        }
        if(!_db.RaceParticipants.Any())
        {
            await RaceParticipantsSeeder.Seed(_db);
        }
        
    }
}