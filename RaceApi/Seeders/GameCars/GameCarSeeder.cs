using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;

namespace RaceApi.Seeders.GameCars;

public static class GameCarSeeder
{
    public static async Task Seed(RaceProjectContext db)
    {
        var game = await db.Game.SingleAsync(g => g.Id == Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6"));

        IEnumerable<Persistence.Models.GameCars> gameCars = [
            new Persistence.Models.GameCars
            {
                Id = Guid.Parse("9f36ec77-83c5-4bd7-999d-b56e49d6acaf"),
                Game = game,
                Car = await db.Cars.SingleAsync(c => c.Id == Guid.Parse("cbfc5a36-9e2d-4b03-9ab8-928de7113293"))!
            },
            new Persistence.Models.GameCars
            {
                Id = Guid.Parse("a17d3c5a-4177-4cd3-ab23-d2e4674f0e13"),
                Game = game,
                Car = (await db.Cars.SingleAsync(car => car.Id == Guid.Parse("29208687-5bb3-4a1e-86c9-d639287a897e")))!
            },
        ];
        
        await db.GameCars.AddRangeAsync(gameCars);
        await db.SaveChangesAsync();
    }

}