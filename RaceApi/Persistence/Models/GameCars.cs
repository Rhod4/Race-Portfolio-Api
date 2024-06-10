using System.ComponentModel.DataAnnotations.Schema;

namespace RaceApi.Persistence.Models;

public class GameCars
{
    public Guid Id { get; set; }
    
    public Guid GameId { get; set; }
    [ForeignKey("GameId")]
    public Game Game { get; set; }
    
    public Guid CarId { get; set; }
    [ForeignKey("CarId")]
    public Cars Car { get; set; }
}