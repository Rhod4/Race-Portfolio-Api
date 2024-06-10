using RaceApi.Models.Dto;

namespace RaceApi.Models.ViewModels.ManualMapViewModels;

public class RaceCardViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public ProfileDetailsViewModel? CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime RaceDate { get; set; }

    public GameDto Game { get; set; }
    
    public string TrackName { get; set; }

    public int RaceParticipants { get; set; }
    public int RaceMarshel { get; set; }
    
    public ICollection<RaceSeriesViewModel> RaceSeries { get; set; } = null!;
}