namespace RaceApi.Persistence.Models;

public class Series
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Cars> Cars { get; set; } = null!;
    public ICollection<RaceSeries> RaceSeries { get; set; } = null!;
}