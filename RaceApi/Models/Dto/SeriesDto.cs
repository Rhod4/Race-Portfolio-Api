namespace RaceApi.Models.Dto;

public class SeriesDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<CarsDto> Cars { get; set; } = null!;
    public ICollection<RaceSeriesDto> RaceSeries { get; set; } = null!;
}