using RaceApi.Persistence;

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
    }
}