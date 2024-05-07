using Microsoft.AspNetCore.Identity;

namespace RaceApi.Persistence.Models;

public class Profile : IdentityUser
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    
    public ICollection<RaceParticipants> RaceParticipants { get; set; } = null!;
    public ICollection<RaceMarshel> RaceMarshel { get; set; } = null!;
}