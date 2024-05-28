using System.ComponentModel.DataAnnotations.Schema;

namespace RaceApi.Persistence.Models;

public class GameSeries
{
    public Guid Id { get; set; }
    
    public Guid GameId { get ; set; }
    [ForeignKey("GameId")]
    public Game Game { get; set; }
    
    public Guid SeriesId { get; set; }
    public Series Series { get; set; }
}