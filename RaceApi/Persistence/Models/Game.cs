using System.ComponentModel.DataAnnotations.Schema;

namespace RaceApi.Persistence.Models;

public class Game
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Track> Tracks { get; set; }
    public ICollection<Race> Races { get; set; }

    public Guid RaceType { get; set; }
    
    public ICollection<GameCars> Cars { get; set; }
}