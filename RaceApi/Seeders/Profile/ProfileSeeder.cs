using RaceApi.Persistence;
using RaceApi.Persistence.Models;

namespace RaceApi.Seeders;


public static class ProfileSeeder
{
    public static async Task Seed( RaceProjectContext db)
    {
        var profile = new Profile
        {
            Id = new Guid(),
            Firstname = "James",
            Lastname = "Fletcher",
            Email = "James@GSnail.com"
        };

        db.Profile.Add(profile);
        await db.SaveChangesAsync();
    }
    
}