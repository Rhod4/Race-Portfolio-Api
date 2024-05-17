using Microsoft.AspNetCore.Mvc;
using RaceApi.Repositories.Races.Interfaces;

namespace RaceApi.Features.ApiMaps.Races;

public abstract class RaceEndpoints
{
    public static void Map(WebApplication app)
    {
        
        app.MapGet("/api/Race/Races", async () =>
            {
                using var scope = app.Services.CreateScope();
                var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();
                
                var races = await raceRepository.GetRaces();

                return Results.Ok(new { Success = races });
            })
            .WithOpenApi();

        app.MapPost("/api/Race/AddUserAsParticipateInRace", async (Guid raceId, int raceNumber) =>
            {
                try{
                    using var scope = app.Services.CreateScope();
                    var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();
                    
                    await raceRepository.AddUserAsParticipateInRace(raceId, "", raceNumber);

                    return Results.Ok(new { Success = "Added To Race" });
                }
                catch(Exception e){
                    return Results.BadRequest(new { Error = e.Message });
                }
            })
            .WithOpenApi()
            .RequireAuthorization();
    }
}