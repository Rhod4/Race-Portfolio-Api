using System.ComponentModel.DataAnnotations.Schema;

namespace RaceApi.Persistence.Models;

public class RaceSeries
{
    public Guid Id { get; set; }
    
    public Guid RaceId { get ; set; }
    [ForeignKey("RaceId")]
    public Race Race { get; set; }
    
    public Guid SeriesId { get; set; }
    public Series Series { get; set; }
}