using RaceApi.Repositories.Games.Interfaces;

namespace RaceApi.Features.Endpoints.Game;

public static class GameEndpoint
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/api/Game/Games", async () =>
            {
                using var scope = app.Services.CreateScope();

                var gameRepository = scope.ServiceProvider.GetRequiredService<IGameRepository>();

                var games = await gameRepository.GetGames();

                return Results.Ok( games );
            })
            .WithOpenApi();
    }
}