using RaceApi.Persistence;

namespace RaceApi.Seeders.Series;

public static class SeriesSeeder
{
    private static readonly List<Persistence.Models.Series> Data = [
        new Persistence.Models.Series
        {
            Id = Guid.Parse("a5bd4f67-afe8-4885-bcaf-55e9725ed81a"),
            Name = "F1"
        },
        new Persistence.Models.Series
        {
            Name = "LMH"
        },
        new Persistence.Models.Series
        {
            Name = "LMDh"
        },
        new Persistence.Models.Series
        {
            Name = "LMP2"
        },
        new Persistence.Models.Series
        {
            Name = "GT2"
        },
        new Persistence.Models.Series
        {
            Id = Guid.Parse("47ef7bc9-69e4-4614-aac6-5f14ebb7afa1"),
            Name = "GT3"
        },
        new Persistence.Models.Series
        {
            Id = Guid.Parse("771fd129-18b7-4514-8fd8-f4ad088ba1c3"),
            Name = "GT4"
        },
    ];
    public static async Task Seed(RaceProjectContext db)
    {
        foreach (var series in Data)
        {
            await db.Series.AddAsync(series);
        }
        await db.SaveChangesAsync();
    }

}