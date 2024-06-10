
namespace RaceApi.Models.ViewModels;

public class RaceMarshelViewModel
{
    public Guid Id { get; set; }
    
    public RaceViewModel Race { get; set; }  
    
    public ProfileViewModel Profile { get; set; }
}