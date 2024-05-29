namespace RaceApi.Models.Requests;

public class CreateRaceRequest
{
    public string Name { get; set; }
    public DateTime RaceDate { get; set; }
    public Guid GameId { get; set; }
    public Guid TrackId { get; set; }
    public Guid SeriesId { get; set; }
}