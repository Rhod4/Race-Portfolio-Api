using RaceApi.Persistence;

namespace RaceApi.Seeders.Location;

public static class LocationSeeder
{
    private static readonly List<Persistence.Models.Location> Data = [
        new Persistence.Models.Location
        {
            Id = Guid.Parse("f4b3b2d4-7b6c-4f5b-9b2d-2b2d4f5b6c7b"),
            Name = "UK"
        },
        new Persistence.Models.Location
        {
            Id = Guid.Parse("05138faa-e375-4263-95e2-956f49be749c"),
            Name = "Italy",
        },
        new Persistence.Models.Location
        {
            Id = Guid.Parse("4a60c0c9-0c97-4790-953e-41dd89641760"),
            Name = "USA",
        },
        new Persistence.Models.Location
        {
            Id = Guid.Parse("cc35291c-cc89-46db-8cb9-73cd7f90714b"),
            Name = "France",
        },
        new Persistence.Models.Location
        {
            Id = Guid.Parse("10b8bc0b-47a1-4de1-863d-a76b0caf3e03"),
            Name = "Spain",
        },
    ];
    public static async Task Seed(RaceProjectContext db)
    {
        foreach (var location in Data)
        {
            await db.Location.AddAsync(location);
        }
        await db.SaveChangesAsync();
    }

}