
namespace RaceApi.Models.Dto;

public class RaceSeriesDto
{
    public Guid Id { get; set; }
    
    public RaceDto Race { get; set; }
    
    public SeriesDto Series { get; set; }
}