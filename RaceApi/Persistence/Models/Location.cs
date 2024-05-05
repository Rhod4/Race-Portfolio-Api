namespace RaceApi.Persistence.Models;

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Track> Tracks { get; set; }
}