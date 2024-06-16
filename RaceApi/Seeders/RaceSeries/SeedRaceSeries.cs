using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;

namespace RaceApi.Seeders.RaceSeries;

public static class RaceSeriesSeeder
{
    
    public static async Task Seed(RaceProjectContext db)
    {

        IEnumerable<Persistence.Models.RaceSeries> raceSeriesData =
        [
            new Persistence.Models.RaceSeries
            {
                Series = await db.Series.SingleAsync(s => s.Id == Guid.Parse("47ef7bc9-69e4-4614-aac6-5f14ebb7afa1")),
                Race = await db.Race.SingleAsync(r => r.Id == Guid.Parse("7b70673b-d00c-49ad-8508-4bb968dd7e06"))
            },
            new Persistence.Models.RaceSeries
            {
                Series = await db.Series.SingleAsync(s => s.Id == Guid.Parse("18FCE74E-21BC-4A27-0E19-08DC7921B9A2")),
                Race = await db.Race.SingleAsync(r => r.Id == Guid.Parse("7b70673b-d00c-49ad-8508-4bb968dd7e06"))
            },
        ];
        
        foreach (var raceSeries in raceSeriesData)
        {
            await db.RaceSeries.AddAsync(raceSeries);
        }
        await db.SaveChangesAsync();
    }

}