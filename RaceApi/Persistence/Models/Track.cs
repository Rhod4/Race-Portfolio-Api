using System.ComponentModel.DataAnnotations.Schema;

namespace RaceApi.Persistence.Models;

public class Track
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public Guid LocationId { get; set; }
    
    [ForeignKey("LocationId")]
    public Location Location { get; set; }
    
    public Guid GameId { get; set; }
    [ForeignKey("GameId")]
    public Game Game { get; set; }
}