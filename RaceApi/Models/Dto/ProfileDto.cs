namespace RaceApi.Models.Dto;

public class ProfileDto
{
    public string Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }

    public ICollection<RaceParticipantsDto> RaceParticipants { get; set; } = null!;
    
    public ICollection<RaceMarshelDto> RaceMarshel { get; set; } = null!;
}