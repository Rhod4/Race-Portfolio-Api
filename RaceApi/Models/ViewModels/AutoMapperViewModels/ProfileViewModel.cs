
namespace RaceApi.Models.ViewModels;

public class ProfileViewModel
{
    public string Id { get; set; } = string.Empty;
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }

    public ICollection<RaceParticipantsViewModel> RaceParticipants { get; set; } = null!;
    
    public ICollection<RaceMarshelViewModel> RaceMarshel { get; set; } = null!;
}