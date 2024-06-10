
namespace RaceApi.Models.ViewModels;

public class TrackViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public LocationViewModel? Location { get; set; }
    
    public GameViewModel? Game { get; set; }
}