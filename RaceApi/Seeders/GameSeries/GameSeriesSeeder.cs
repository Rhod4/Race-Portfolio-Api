using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;

namespace RaceApi.Seeders.GameSeries;

public class GameSeriesSeeder
{
    public static async Task Seed(RaceProjectContext db)
    {

        IEnumerable<Persistence.Models.GameSeries> gameSeriesData =
        [
            new Persistence.Models.GameSeries
            {
                Series = await db.Series.SingleAsync(s => s.Id == Guid.Parse("47ef7bc9-69e4-4614-aac6-5f14ebb7afa1")),
                Game = await db.Game.SingleAsync(r => r.Id == Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6"))
            },
            new Persistence.Models.GameSeries
            {
                Series = await db.Series.SingleAsync(s => s.Id == Guid.Parse("47ef7bc9-69e4-4614-aac6-5f14ebb7afa1")),
                Game = await db.Game.SingleAsync(r => r.Id == Guid.Parse("7e7cf39d-0f03-4290-98ca-87e155e794ce"))
            },
            new Persistence.Models.GameSeries
            {
                Series = await db.Series.SingleAsync(s => s.Id == Guid.Parse("a5bd4f67-afe8-4885-bcaf-55e9725ed81a")),
                Game = await db.Game.SingleAsync(r => r.Id == Guid.Parse("7e7cf39d-0f03-4290-98ca-87e155e794ce"))
            },
        ];
        
        foreach (var gameSeries in gameSeriesData)
        {
            await db.GameSeries.AddAsync(gameSeries);
        }
        await db.SaveChangesAsync();
    }
}