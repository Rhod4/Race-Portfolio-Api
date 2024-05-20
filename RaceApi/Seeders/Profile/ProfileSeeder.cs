using Microsoft.AspNetCore.Identity;
using RaceApi.Persistence;

namespace RaceApi.Seeders.Profile;

public static class ProfileSeeder
{
    private static readonly IEnumerable<ProfileSeedingModel> Profiles =
    [
        new ProfileSeedingModel
        {
            Username = "test",
            FirstName = "James",
            LastName = "Fletcher",
            Email = "T@T.com",
            Password = "Test123!" 
        },
        new ProfileSeedingModel
        {
            Username = "user",
            FirstName = "garry",
            LastName = "Account",
            Email = "Admin@Race.com",
            Password = "Test123!" 
        },
        new ProfileSeedingModel
        {
            Username = "admin",
            FirstName = "Admin",
            LastName = "Account",
            Email = "Admin@Race.com",
            Password = "Test123!" 
        },
    ];
    
    public static async Task Seed(RaceProjectContext db)
    {
        foreach (var profile in Profiles)
        {
            var profileForDb = new Persistence.Models.Profile
            {
                UserName = profile.Username,
                Firstname = profile.FirstName,
                Lastname = profile.LastName,
                Email = profile.Email,
            };
            
            var passwordHasher = new PasswordHasher<Persistence.Models.Profile>();        
            
            var hashedPassword = passwordHasher.HashPassword(profileForDb, profile.Password);

            profileForDb.PasswordHash = hashedPassword;
            
            await db.Profile.AddAsync(profileForDb);
            await db.SaveChangesAsync();
        }
    }
    
}