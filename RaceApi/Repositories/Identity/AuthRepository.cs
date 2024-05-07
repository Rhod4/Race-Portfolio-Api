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

    public async Task<bool> LoginSuccess(string username, string password)
    {
        var user = _db.Profile.SingleOrDefault(p => p.UserName == username);

        if (user == null ||  user.PasswordHash == null)
        {
            return false;
        }

        var passwordHasher = new PasswordHasher<Profile>();
        
        var verifyPassword = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

        return verifyPassword == PasswordVerificationResult.Success;
    }
}