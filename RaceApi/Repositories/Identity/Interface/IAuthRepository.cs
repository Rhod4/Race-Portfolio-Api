namespace RaceApi.Repositories.Identity.Interface;

public interface IAuthRepository
{
    public Task<Guid?> LoginSuccess(string username, string password);
}