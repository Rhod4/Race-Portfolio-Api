namespace RaceApi.Models.Dto;

public class RaceMarshelDto
{
    public Guid Id { get; set; }
    
    public RaceDto Race { get; set; }  
    
    public ProfileDto Profile { get; set; }
}