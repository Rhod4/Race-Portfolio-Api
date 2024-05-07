using System.ComponentModel.DataAnnotations.Schema;

namespace RaceApi.Persistence.Models;

public class RaceMarshel
{
    public Guid Id { get; set; }
    
    public Guid RaceId { get; set; }
    [ForeignKey("RaceId")]
    public Race Race { get; set; }  
    
    public string ProfileId { get; set; }
    [ForeignKey("ProfileId")]
    public Profile Profile { get; set; }
}