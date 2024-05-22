
namespace RaceApi.Models.ViewModels;

public class LocationViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<TrackViewModel> Tracks { get; set; }
}