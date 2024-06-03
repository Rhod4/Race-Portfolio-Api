
namespace RaceApi.Models.ViewModels;

public class RaceParticipantsViewModel
{
    
    public Guid Id { get; set; }
    
    public Guid RaceId { get; set; }
    public RaceViewModel Race { get; set; }
    public ProfileViewModel Profile { get; set; }
    public CarsViewModel Car { get; set; } = null!;
    
    public int UserRaceNumber { get; set; }
}