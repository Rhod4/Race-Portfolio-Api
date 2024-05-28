using RaceApi.Persistence;

namespace RaceApi.Seeders.Game;

public class GameSeeder
{
    public static async Task Seed(RaceProjectContext db)
    {
        IEnumerable<Persistence.Models.Game> game =
        [
            new Persistence.Models.Game
            {
                Id = Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6"),
                Name = "IRacing"
            },
            new Persistence.Models.Game
            {
                Id = Guid.Parse("111e13cc-fbb8-482f-9c56-69e138b2b2a4"),
                Name = "Assetto Corsa",
            },
            new Persistence.Models.Game
            {
                Id = Guid.Parse("7e7cf39d-0f03-4290-98ca-87e155e794ce"),
                Name = "Automobilista 2",
            }
        ];

        await db.Game.AddRangeAsync(game);
        await db.SaveChangesAsync();
    }
}