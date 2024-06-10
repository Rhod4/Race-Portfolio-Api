
namespace RaceApi.Models.Dto;

public class CarsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public Guid SeriesId { get; set; }
    
    public SeriesDto Series { get; set; }

    public ICollection<GameCarsDto> Games { get; set; } = null!;

}