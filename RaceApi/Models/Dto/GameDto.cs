namespace RaceApi.Models.Dto;

public class GameDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public required ICollection<TrackDto> Tracks { get; set; }
    public required ICollection<RaceDto> Races { get; set; }

    public Guid RaceType { get; set; }
    
    public required ICollection<GameCarsDto> Cars { get; set; }
}