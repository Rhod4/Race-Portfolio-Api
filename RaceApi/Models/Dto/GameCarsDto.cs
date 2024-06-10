namespace RaceApi.Models.Dto;

public class GameCarsDto
{
    public Guid Id { get; set; }
    
    public required GameDto Game { get; set; }
    public required CarsDto Car { get; set; }
}