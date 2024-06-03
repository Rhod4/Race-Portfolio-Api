using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RaceApi.Models.Dto;
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

            return Results.Ok(races.Select(mapper.Map<RaceViewModel>));

        })
        .WithOpenApi()
        .RequireAuthorization();

        app.MapPost("/api/AdminRace/CreateRace", async (CreateRaceRequest createRaceRequest, HttpContext httpContext) =>
        {
            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
            var user = await userManager.GetUserAsync(httpContext.User);
            
            if(user == null)
                return Results.BadRequest(new { Error = "Please Log In" });
            
            using var scope = app.Services.CreateScope();
            var raceSeriesService = scope.ServiceProvider.GetRequiredService<ICreateRaceService>();

            var race = new RaceDto();
            
            if (createRaceRequest.Id == null)
            {
                race = await raceSeriesService.CreateCompleteRaceByGame(createRaceRequest, user);
            }
            else
            {
                race = await raceSeriesService.EditCompleteRaceByGame(createRaceRequest, user);
            }


            return Results.Ok(race);
        })
        .WithOpenApi()
        .RequireAuthorization();
        
        app.MapGet("api/AdminRace/{id}", async (string id, HttpContext httpContext) =>
            {
                var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
                var user = await userManager.GetUserAsync(httpContext.User);
            
                if(user == null)
                    return Results.BadRequest(new { Error = "Please Log In" });
                
                var raceId = Guid.Parse(id);

                using var scope = app.Services.CreateScope();
                var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

                var race = await raceRepository.GetRace(raceId);
                
                var raceViewModel = mapper.Map<RaceViewModel>(race);

                return Results.Ok(raceViewModel);
            })
            .WithOpenApi()
            .RequireAuthorization();
        
        app.MapDelete("api/AdminRace/RemoveRace/{id}", async (string id, HttpContext httpContext) =>
            {
                var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
                var user = await userManager.GetUserAsync(httpContext.User);
            
                if(user == null)
                    return Results.BadRequest(new { Error = "Please Log In" });
                
                var raceId = Guid.Parse(id);

                using var scope = app.Services.CreateScope();
                var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

                var raceRemoved = await raceRepository.RemoveRace(raceId);

                return Results.Ok(raceRemoved);
            })
            .WithOpenApi()
            .RequireAuthorization();

    }
}