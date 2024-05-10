using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;

namespace RaceApi.Seeders.Track;

public class TracksSeeder
{

    public static async Task Seed(RaceProjectContext db)
    {
        var game = await db.Game.SingleAsync(g => g.Id == Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6"));
        var tracks =
            new Persistence.Models.Track
            {
                Id = Guid.Parse("45be25d8-6f44-488c-addf-cecf4ef52497"),
                Name = "Silverstone",
                LocationId = Guid.Parse("f4b3b2d4-7b6c-4f5b-9b2d-2b2d4f5b6c7b"),
                GameId = game.Id,
                Game = game
            };
        
        await db.Track.AddAsync(tracks);
        await db.SaveChangesAsync();
    }
}