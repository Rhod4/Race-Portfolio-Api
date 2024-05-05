namespace RaceApi.Persistence.Models;

public class OfficialRoles
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Role> Roles { get; set; } = null!;
}