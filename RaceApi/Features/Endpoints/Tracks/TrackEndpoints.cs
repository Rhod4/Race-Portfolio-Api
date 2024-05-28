using Microsoft.AspNetCore.Mvc;
using RaceApi.Repositories.Tracks.Interfaces;

namespace RaceApi.Features.ApiMaps.Tracks;

public class TrackEndpoints
{
    public static void Map(WebApplication app)
    {

        app.MapGet("/api/Track/Tracks", async () =>
            {
                using var scope = app.Services.CreateScope();
                var trackRepository = scope.ServiceProvider.GetRequiredService<ITrackRepository>();
                
                var tracks = await trackRepository.GetTracks();

                return Results.Ok(new { Success = tracks });
            })
            .WithOpenApi();

        app.MapGet("/api/Track/AllTracksByGame", async (Guid game) =>
            {
                using var scope = app.Services.CreateScope();
                var trackRepository = scope.ServiceProvider.GetRequiredService<ITrackRepository>();
                
                var tracks = await trackRepository.GetTracksByGame(game);

                return Results.Ok(new { Success = tracks });
            })
            .WithOpenApi();
        
        app.MapGet("/api/Track/AllTracksByCountry", async (Guid country, Guid? game) =>
            {
                using var scope = app.Services.CreateScope();
                var trackRepository = scope.ServiceProvider.GetRequiredService<ITrackRepository>();
                
                var tracks = await trackRepository.GetTracksByCountry(country, game);

                return Results.Ok(new { Success = tracks });
            })
            .WithOpenApi();
    }
}