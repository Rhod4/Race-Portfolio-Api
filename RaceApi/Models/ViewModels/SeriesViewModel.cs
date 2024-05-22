namespace RaceApi.Models.ViewModels;

public class SeriesViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<CarsViewModel> Cars { get; set; } = null!;
    public ICollection<RaceSeriesViewModel> RaceSeries { get; set; } = null!;
}