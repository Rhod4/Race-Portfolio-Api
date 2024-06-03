using RaceApi.Persistence.Models;

namespace RaceApi.Models.Dto.Races;

public class CreateOrEditRace
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public Profile CreatedBy { get; set; }
    public DateTime RaceDate { get; set; }

    public GameDto Game { get; set; }

    public TrackDto Track { get; set; }
};
