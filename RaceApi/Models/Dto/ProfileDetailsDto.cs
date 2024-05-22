namespace RaceApi.Models.Dto;

public class ProfileDetailsDto
{
    public required string UserId { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
}