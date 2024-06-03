
namespace RaceApi.Models.ViewModels;

public class RaceViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public ProfileDetailsViewModel? CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public ProfileDetailsViewModel? UpdatedBy { get; set; }
    public DateTime RaceDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
    public ProfileDetailsViewModel? DeletedBy { get; set; }

    public GameViewModel? Game { get; set; }
    
    public TrackViewModel? Track { get; set; }

    public ICollection<RaceParticipantsViewModel> RaceParticipants { get; set; } = null!;
    public ICollection<RaceMarshelViewModel> RaceMarshel { get; set; } = null!;
    
    public ICollection<RaceSeriesViewModel> RaceSeries { get; set; } = null!;
    
}