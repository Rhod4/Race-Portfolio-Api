using RaceApi.Persistence;
using RaceApi.Seeders.Game;
using RaceApi.Seeders.Location;
using RaceApi.Seeders.Profile;
using RaceApi.Seeders.Race;
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
        if(!_db.Track.Any())
        {
            await TracksSeeder.Seed(_db);
        }
        if(!_db.Race.Any())
        {
            await RaceSeeder.Seed(_db);
        }
    }
}