using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;

namespace RaceApi.Seeders.Race;

public class RaceSeeder
{
    public static async Task Seed(RaceProjectContext db)
    {
        List<Persistence.Models.Race> races =
        [
            CreateRaceForSeeding(
                Guid.Parse("7b70673b-d00c-49ad-8508-4bb968dd7e06"),
                "Main Race",
                new DateTime(2025, 03, 01),
                await db.Profile.SingleAsync(p => p.UserName == "admin"),
                await db.Game.SingleAsync(p => p.Id == Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6")),
                await db.Track.SingleAsync(p => p.Id == Guid.Parse("45be25d8-6f44-488c-addf-cecf4ef52497"))),
            CreateRaceForSeeding(
                Guid.Parse("e3744601-57e3-446f-83ca-a91d8ea7e0cb"),
                "Race Silverstone Pat 1",
                new DateTime(2025, 04, 01),
                await db.Profile.SingleAsync(p => p.UserName == "admin"),
                await db.Game.SingleAsync(p => p.Id == Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6")),
                await db.Track.SingleAsync(p => p.Id == Guid.Parse("45be25d8-6f44-488c-addf-cecf4ef52497"))),
            CreateRaceForSeeding(
                Guid.Parse("0074bbd2-f32e-46c5-b8ef-35f1691d2e34"),
                "Race Silverstone Part 2",
                new DateTime(2025, 04, 11),
                await db.Profile.SingleAsync(p => p.UserName == "admin"),
                await db.Game.SingleAsync(p => p.Id == Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6")),
                await db.Track.SingleAsync(p => p.Id == Guid.Parse("45be25d8-6f44-488c-addf-cecf4ef52497"))),
        ];
        
        for (int i = 0; i <= 25; i++)
        {
            races.Add(
                CreateRaceForSeeding(
                    Guid.NewGuid(),
                    $"Race {i}",
                    new DateTime(2026, 08, 11),
                    await db.Profile.SingleAsync(p => p.UserName == "admin"),
                    await db.Game.SingleAsync(p => p.Id == Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6")),
                    await db.Track.SingleAsync(p => p.Id == Guid.Parse("45be25d8-6f44-488c-addf-cecf4ef52497")))
                );
        }

        await db.Race.AddRangeAsync(races);
        await db.SaveChangesAsync();
    }

    private static Persistence.Models.Race CreateRaceForSeeding(
        Guid id,
        string name,
        DateTime raceDate,
        Persistence.Models.Profile createdBy
        , Persistence.Models.Game game
        , Persistence.Models.Track track)
    {
        return new Persistence.Models.Race
        {
            Id = id,
            Name = name,
            CreatedOn = new DateTime(),
            CreatedBy = createdBy,
            UpdatedOn = null,
            UpdatedBy = null,
            RaceDate = raceDate,
            IsDeleted = false,
            DeletedOn = null,
            DeletedBy = null,
            GameId = game.Id,
            Game = game,
            TrackId = track.Id,
            Track = track,
            RaceParticipants = [],
            RaceMarshel = []
        };
    }
}