using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;

namespace RaceApi.Seeders.Race;

public class RaceSeeder
{
    public static async Task Seed(RaceProjectContext db)
    {
        var createdByProfile = await db.Profile.SingleAsync(p => p.UserName == "admin");
        var game = await db.Game.SingleAsync(p => p.Id == Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6"));
        var track = await db.Track.SingleAsync(p => p.Id == Guid.Parse("45be25d8-6f44-488c-addf-cecf4ef52497"));

        var race = new Persistence.Models.Race
        {
            Id = new Guid(),
            Name = "Race 1",
            CreatedOn = default,
            CreatedBy = createdByProfile,
            UpdatedOn = null,
            UpdatedBy = null,
            RaceDate = new DateTime(2025,09,01),
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

        await db.Race.AddAsync(race);
        await db.SaveChangesAsync();
    }
}