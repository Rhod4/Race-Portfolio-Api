using RaceApi.Persistence;
using RaceApi.Repositories.Identity.Interface;

namespace RaceApi.Repositories.Identity;

public class AuthRepository: IAuthRepository
{
    private readonly RaceProjectContext _db;

    public AuthRepository(RaceProjectContext db)
    {
        _db = db;
    }
}