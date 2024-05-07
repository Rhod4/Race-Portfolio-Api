namespace RaceApi.Repositories.Identity.Interface;

public interface IAuthRepository
{
    public Task<bool> LoginSuccess(string username, string password);
}