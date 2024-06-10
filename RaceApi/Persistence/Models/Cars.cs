using System.ComponentModel.DataAnnotations.Schema;

namespace RaceApi.Persistence.Models;

public class Cars
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public Guid SeriesId { get; set; }
    [ForeignKey("SeriesId")]
    public Series Series { get; set; }

    public ICollection<GameCars> Games { get; set; } = null!;

}