
namespace RaceApi.Models.ViewModels;

public class RaceSeriesViewModel
{
    public Guid Id { get; set; }
    
    public RaceViewModel Race { get; set; }
    
    public SeriesViewModel Series { get; set; }
}