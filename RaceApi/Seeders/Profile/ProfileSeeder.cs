using Microsoft.AspNetCore.Identity;
using RaceApi.Persistence;

namespace RaceApi.Seeders.Profile;

public static class ProfileSeeder
{
    public static async Task Seed( RaceProjectContext db)
    {
        var passwordHasher = new PasswordHasher<Persistence.Models.Profile>();        
        
        var profile = new Persistence.Models.Profile
        {
            UserName = "test",
            Firstname = "James",
            Lastname = "Fletcher",
            Email = "James@GSnail.com",
        };
        
        var hashedPassword = passwordHasher.HashPassword(profile, "Password123");

        profile.PasswordHash = hashedPassword;
        
        db.Profile.Add(profile);
        await db.SaveChangesAsync();
    }
    
}