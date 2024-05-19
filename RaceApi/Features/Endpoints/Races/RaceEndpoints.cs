using Microsoft.AspNetCore.Identity;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Races.Interfaces;

namespace RaceApi.Features.Endpoints.Races;

public abstract class RaceEndpoints
{
    public static void Map(WebApplication app)
    {
        
        app.MapGet("/api/Race/Races/{total:int?}", async (int? total) =>
            {
                using var scope = app.Services.CreateScope();
                var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();
                
                var races = await raceRepository.GetRaces(total);

                return Results.Ok(new { Success = races });
            })
            .WithOpenApi();

        app.MapGet("api/Race/Race/{id}", async (string id, HttpContext httpContext) =>
        {
            var raceId = Guid.Parse(id);
            
            using var scope = app.Services.CreateScope();
            var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

            var race = await raceRepository.GetRace(raceId);
            
            return Results.Ok(new { race });
        })
        .WithOpenApi()
        .RequireAuthorization();

        app.MapPost("/api/Race/ParticipateInRace", async (Guid raceId, int raceNumber, HttpContext httpContext) =>
            {
                try
                {
                    var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
                    var user = await userManager.GetUserAsync(httpContext.User);
                    
                    if (user == null)
                        return Results.BadRequest(new { Error = "Error getting details" });
                    
                    using var scope = app.Services.CreateScope();
                    var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

                    if (await raceRepository.AlreadyParticipating(raceId, user.Id))
                        return Results.BadRequest(new { Error = "Already Participating" });
                    
                    await raceRepository.AddUserToRaceParticipants(raceId, user.Id, raceNumber);

                    return Results.Ok(new { Success = "Added To Race" });
                }
                catch(Exception e){
                    return Results.BadRequest(new { Error = e.Message });
                }
            })
            .WithOpenApi()
            .RequireAuthorization();
        
        app.MapPost("/api/Race/RemoveParticipateInRace", async (Guid raceId, HttpContext httpContext) =>
            {
                try
                {
                    var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
                    var user = await userManager.GetUserAsync(httpContext.User);
                    
                    if (user == null)
                        return Results.BadRequest(new { Error = "Error getting details" });
                    
                    using var scope = app.Services.CreateScope();
                    var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

                    if (!await raceRepository.AlreadyParticipating(raceId, user.Id))
                        return Results.BadRequest(new { Error = "User Not Already Participating" });
                    
                    await raceRepository.RemoveUserFromRaceParticipants(raceId, user.Id);

                    return Results.Ok(new { Success = "Removed From Race" });
                }
                catch(Exception e){
                    return Results.BadRequest(new { Error = e.Message });
                }
            })
            .WithOpenApi()
            .RequireAuthorization();app.MapPost("/api/Race/RemoveParticipateInRace", async (Guid raceId, HttpContext httpContext) =>
            {
                try
                {
                    var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
                    var user = await userManager.GetUserAsync(httpContext.User);
                    
                    if (user == null)
                        return Results.BadRequest(new { Error = "Error getting details" });
                    
                    using var scope = app.Services.CreateScope();
                    var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

                    var isParticipating = await raceRepository.AlreadyParticipating(raceId, user.Id);

                    return Results.Ok(new { isParticipating });
                }
                catch(Exception e){
                    return Results.BadRequest(new { Error = e.Message });
                }
            })
            .WithOpenApi()
            .RequireAuthorization();
    }
}