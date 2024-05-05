namespace RaceApi.Persistence.Models;

public class Profile 
{
    public Guid Id { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    public ICollection<RaceParticipants> RaceParticipants { get; set; } = null!;
    public ICollection<RaceMarshel> RaceMarshel { get; set; } = null!;
}