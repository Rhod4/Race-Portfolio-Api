
namespace RaceApi.Models.ViewModels;

public class GameCarsViewModel
{
    public Guid Id { get; set; }
    
    public required GameViewModel Game { get; set; }
    public required CarsViewModel Car { get; set; }
}