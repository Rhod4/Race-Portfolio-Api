
namespace RaceApi.Models.Dto;

public class LocationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<TrackDto> Tracks { get; set; }
}