using RaceApi.Persistence;

namespace RaceApi.Seeders.Game;

public class GameSeeder
{
    public static async Task Seed(RaceProjectContext db)
    {
        var game = new Persistence.Models.Game
        {
            Id = Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6"),
            Name = "IRacing",
            RaceType = Guid.Parse("e74d57f7-ff54-4d0b-8d84-71e4b7e5441b")
        };

        await db.Game.AddAsync(game);
        await db.SaveChangesAsync();
    }

}