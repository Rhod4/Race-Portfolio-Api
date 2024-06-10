
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceApi.Persistence.Models;

public class Race
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    [ForeignKey(nameof(Profile))]
    public string CreatedById { get; set; }
    public Profile CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public Profile? UpdatedBy { get; set; }
    public DateTime RaceDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
    public Profile? DeletedBy { get; set; }

    [ForeignKey(nameof(Game))]
    public Guid GameId { get; set; }
    public Game Game { get; set; }
    
    [ForeignKey(nameof(Track))]
    public Guid TrackId { get; set; }
    public Track Track { get; set; }

    public ICollection<RaceParticipants> RaceParticipants { get; set; } = null!;
    public ICollection<RaceMarshel> RaceMarshel { get; set; } = null!;
    
    public ICollection<RaceSeries> RaceSeries { get; set; } = null!;
    
}