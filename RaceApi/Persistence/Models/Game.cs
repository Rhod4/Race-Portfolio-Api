namespace RaceApi.Persistence.Models;

public class Game
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    
    public ICollection<Track> Track { get; set; }
    public Guid RaceType { get; set; }
}