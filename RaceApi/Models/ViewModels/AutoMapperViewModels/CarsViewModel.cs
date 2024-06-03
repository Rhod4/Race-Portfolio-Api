
namespace RaceApi.Models.ViewModels;

public class CarsViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public Guid SeriesId { get; set; }
    
    public SeriesViewModel Series { get; set; }

    public ICollection<GameCarsViewModel> Games { get; set; } = null!;

}