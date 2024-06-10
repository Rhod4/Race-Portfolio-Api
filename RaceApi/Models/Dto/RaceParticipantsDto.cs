namespace RaceApi.Models.Dto;

public class RaceParticipantsDto
{
    
    public Guid Id { get; set; }
    
    public RaceDto Race { get; set; }
    public ProfileDto Profile { get; set; }
    public CarsDto Car { get; set; } = null!;
    
    public int UserRaceNumber { get; set; }
}