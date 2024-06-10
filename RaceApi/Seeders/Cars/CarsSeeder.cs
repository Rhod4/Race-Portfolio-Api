using RaceApi.Persistence;
using RaceApi.Persistence.Models;

namespace RaceApi.Seeders.Cars;

public static class CarsSeeder
{
    private static readonly List<Persistence.Models.Cars> Data = [
        new Persistence.Models.Cars
        {
            Id = Guid.Parse("cbfc5a36-9e2d-4b03-9ab8-928de7113293"),
            Name = "Ferrari 296 GT3",
            SeriesId = Guid.Parse("47ef7bc9-69e4-4614-aac6-5f14ebb7afa1")
        },
        new Persistence.Models.Cars
        {
            Id = Guid.Parse("29208687-5bb3-4a1e-86c9-d639287a897e"),
            Name = "Porsche 911 GT3 R",
            SeriesId = Guid.Parse("47ef7bc9-69e4-4614-aac6-5f14ebb7afa1")
        },
    ];
    public static async Task Seed(RaceProjectContext db)
    {
        
        
        foreach (var cars in Data)
        {
            var game = db.Game.First(game => game.Id == Guid.Parse("88116dc3-78bf-4bcf-97ab-1a45ae1470e6"));

            await db.GameCars.AddAsync(new Persistence.Models.GameCars
            {
                Game = game,
                Car = cars
            });
            
            await db.Cars.AddAsync(cars);
            await db.SaveChangesAsync();
        }
    }

}