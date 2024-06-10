using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RaceApi.Persistence.Models;

public class Profile : IdentityUser
{
    [MaxLength(50)]
    public string? Firstname { get; set; }
    [MaxLength(50)]
    public string? Lastname { get; set; }
    
    public ICollection<RaceParticipants> RaceParticipants { get; set; } = null!;
    public ICollection<RaceMarshel> RaceMarshel { get; set; } = null!;
}

