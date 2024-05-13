using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;

namespace RaceApi.Seeders.Track;

public class TracksSeeder
{
    private static readonly IEnumerable<Persistence.Models.Track> UkTrack =
        [
        new Persistence.Models.Track
        {
        Id = Guid.Parse("45be25d8-6f44-488c-addf-cecf4ef52497"),
        Name = "Silverstone",
        LocationId = Guid.Parse("f4b3b2d4-7b6c-4f5b-9b2d-2b2d4f5b6c7b"),
        },
        new Persistence.Models.Track
        {
            Id = Guid.Parse("6816d0b6-b0d3-455d-b599-975b2b512d42"),
            Name = "Brands Hatch",
            LocationId = Guid.Parse("f4b3b2d4-7b6c-4f5b-9b2d-2b2d4f5b6c7b"),
        },
        new Persistence.Models.Track
        {
            Id = Guid.Parse("57828861-31b7-41c8-9b91-03065395b200"),
            Name = "Donington Park",
            LocationId = Guid.Parse("f4b3b2d4-7b6c-4f5b-9b2d-2b2d4f5b6c7b"),
        }
        ];
    private static readonly IEnumerable<Persistence.Models.Track> ItalianTrack =
        [
        new Persistence.Models.Track
        {
            Id = Guid.Parse("c2fc6e3f-6997-48e7-acc7-de0fad321877"),
            Name = "Monza",
            LocationId = Guid.Parse("05138faa-e375-4263-95e2-956f49be749c"),
        },
        new Persistence.Models.Track
        {
            Id = Guid.Parse("b3bff62a-25c6-4ee6-9cc4-3c77d46b1f7c"),
            Name = "Imola",
            LocationId = Guid.Parse("05138faa-e375-4263-95e2-956f49be749c"),
        },
        new Persistence.Models.Track
        {
            Id = Guid.Parse("1a507daa-d326-4671-8c6a-5e8c48874567"),
            Name = "Mugello",
            LocationId = Guid.Parse("05138faa-e375-4263-95e2-956f49be749c"),
        }
        ];

    private static async Task<IEnumerable<Persistence.Models.Track>> TracksByGame(RaceProjectContext db,
        List<Persistence.Models.Track> tracks, string gameId)
    {
        var game = await db.Game.SingleAsync(g => g.Id == Guid.Parse(gameId));

        var track = tracks.Select(t =>
        {
            t.GameId = game.Id;
            t.Game = game;
            return t;
        });

        return track;
    }
    
    public static async Task Seed(RaceProjectContext db)
    {
        var ukTracks = await TracksByGame(db, UkTrack.ToList(), "88116dc3-78bf-4bcf-97ab-1a45ae1470e6");
        var italianTracks = await TracksByGame(db, ItalianTrack.ToList(), "88116dc3-78bf-4bcf-97ab-1a45ae1470e6");

        List<Persistence.Models.Track> track = [..ukTracks.ToList(), ..italianTracks.ToList()];
        
        await db.Track.AddRangeAsync(track);
        await db.SaveChangesAsync();
    }
}