using RaceApi.Persistence;

namespace RaceApi.Seeders.Location;

public static class LocationSeeder
{
    public static async Task Seed(RaceProjectContext db)
    {
        var location = new Persistence.Models.Location
        {
            Id = Guid.Parse("f4b3b2d4-7b6c-4f5b-9b2d-2b2d4f5b6c7b"),
            Name = "Silverstone"
        };
        
        await db.Location.AddAsync(location);
        await db.SaveChangesAsync();
    }

}