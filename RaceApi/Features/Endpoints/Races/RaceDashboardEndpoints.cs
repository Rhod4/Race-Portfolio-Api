using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RaceApi.Models.Requests;
using RaceApi.Models.ViewModels;
using RaceApi.Repositories.Races.Interfaces;
using RaceApi.Services.Interfaces;
using Profile = RaceApi.Persistence.Models.Profile;

namespace RaceApi.Features.Endpoints.Races;

public static class RaceDashboardEndpoints
{
    public static void Map(WebApplication app, IMapper mapper)
    {
        app.MapGet("/api/AdminRace/GetAdminRacesForLoggedInUser", async (HttpContext httpContext) =>
        {
            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
            var user = await userManager.GetUserAsync(httpContext.User);
            
            if(user == null)
                return Results.BadRequest(new { Error = "Error getting details" });
            
            using var scope = app.Services.CreateScope();
            var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

            var races = await raceRepository.GetRaceForUser(user.Id);

            return Results.Ok(new { adminRaces = races.Select(mapper.Map<RaceViewModel>)});

        })
        .WithOpenApi()
        .RequireAuthorization();

        app.MapPost("/api/AdminRace/CreateRace", async (CreateRaceRequest createRaceRequest, HttpContext httpContext) =>
        {
            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
            var user = await userManager.GetUserAsync(httpContext.User);
            
            if(user == null)
                return Results.BadRequest(new { Error = "Error getting details" });
            
            using var scope = app.Services.CreateScope();
            var raceSeriesService = scope.ServiceProvider.GetRequiredService<ICreateRaceService>();

            var race = await raceSeriesService.CreateCompleteRaceByGame(createRaceRequest, user);

            return Results.Ok(race);
        })
        .WithOpenApi()
        .RequireAuthorization();
    }
}