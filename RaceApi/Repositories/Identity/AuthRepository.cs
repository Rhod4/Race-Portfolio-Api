using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Identity.Interface;

namespace RaceApi.Repositories.Identity;

public class AuthRepository: IAuthRepository
{
    private readonly RaceProjectContext _db;

    public AuthRepository(RaceProjectContext db)
    {
        _db = db;
    }

    public async Task<Guid?> LoginSuccess(string username, string password)
    {
        var user = _db.Profile.SingleOrDefault(p => p.UserName == username);

        if (user?.PasswordHash == null)
        {
            return null;
        }
        
        var passwordHasher = new PasswordHasher<Profile>();
        
        var verifyPassword = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

        if (verifyPassword == PasswordVerificationResult.Success)
        {
            return Guid.Parse(user.Id);
        }
        return null;
    }
}