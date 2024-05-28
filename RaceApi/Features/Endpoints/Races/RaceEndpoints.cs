using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RaceApi.Models.ViewModels;
using RaceApi.Repositories.Races.Interfaces;
using Profile = RaceApi.Persistence.Models.Profile;

namespace RaceApi.Features.Endpoints.Races;

public static class RaceEndpoints
{
    public static void Map(WebApplication app, IMapper mapper)
    {
        app.MapGet("/api/Race/Races/{total:int?}", async (int? total) =>
            {
                using var scope = app.Services.CreateScope();
                var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

                var races = (await raceRepository.GetRaces(total)).ToList();

                var racesViewModel = races.Select(mapper.Map<RaceViewModel>);
                
                return Results.Ok(racesViewModel);
            })
            .WithOpenApi();

        app.MapGet("api/Race/Race/{id}", async (string id, HttpContext httpContext) =>
            {
                var raceId = Guid.Parse(id);

                using var scope = app.Services.CreateScope();
                var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

                var race = await raceRepository.GetRace(raceId);
                
                var raceViewModel = mapper.Map<RaceViewModel>(race);

                return Results.Ok(raceViewModel);
            })
            .WithOpenApi()
            .RequireAuthorization();

        app.MapPost("/api/Race/ParticipateInRace", async (Guid raceId, int raceNumber, Guid carId, HttpContext httpContext) =>
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

                    await raceRepository.AddUserToRaceParticipants(raceId, user.Id, raceNumber, carId);

                    return Results.Ok(new { Success = "Added To Race" });
                }
                catch (Exception e)
                {
                    return Results.BadRequest(new { Error = e.Message });
                }
            })
            .WithOpenApi()
            .RequireAuthorization();

        app.MapPost("/api/Race/RemoveParticipateInRace/{raceId:Guid}", async (Guid raceId, HttpContext httpContext) =>
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
                catch (Exception e)
                {
                    return Results.BadRequest(new { Error = e.Message });
                }
            })
            .WithOpenApi()
            .RequireAuthorization();

        app.MapPost("/api/Race/AlreadyRacing/{raceId:Guid}", async (Guid raceId, HttpContext httpContext) =>
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
                catch (Exception e)
                {
                    return Results.BadRequest(new { Error = e.Message });
                }
            })
            .WithOpenApi()
            .RequireAuthorization();
        
        app.MapGet("/api/Race/GetParticipants/{raceId:guid}", async (Guid raceId) =>
            {
                using var scope = app.Services.CreateScope();
                var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

                var participants = (await raceRepository.GetRaceParticipants(raceId)).ToList();

                var participantsViewModel = participants.Select(mapper.Map<RaceParticipantsViewModel>);
                
                return Results.Ok(new { participantsViewModel });
            })
            .WithOpenApi();

        app.MapGet("/api/Race/GetRacesForLoggedInUser", async (HttpContext httpContext) =>
        {
            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
            var user = await userManager.GetUserAsync(httpContext.User);
            
        }).WithOpenApi().RequireAuthorization();
    }
}