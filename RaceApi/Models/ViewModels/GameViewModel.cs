
namespace RaceApi.Models.ViewModels;

public class GameViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public required ICollection<TrackViewModel> Tracks { get; set; }
    public required ICollection<RaceViewModel> Races { get; set; }

    public Guid RaceType { get; set; }
    
    public required ICollection<GameCarsViewModel> Cars { get; set; }
}