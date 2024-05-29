
namespace RaceApi.Models.Dto;

public class RaceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public ProfileDto? CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public ProfileDto? UpdatedBy { get; set; }
    public DateTime RaceDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
    public ProfileDto? DeletedBy { get; set; }

    public GameDto? Game { get; set; }
    
    public TrackDto? Track { get; set; }

    public ICollection<RaceParticipantsDto> RaceParticipants { get; set; } = null!;
    public ICollection<RaceMarshelDto> RaceMarshel { get; set; } = null!;
    
    public ICollection<RaceSeriesDto> RaceSeries { get; set; } = null!;
    
}