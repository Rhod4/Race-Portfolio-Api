using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RaceApi.Models.Mappers.DtoToViewModels;
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

        app.MapGet("/api/Race/GetRacesForLoggedInUser", async (HttpContext httpContext) =>
        {
            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
            var user = await userManager.GetUserAsync(httpContext.User);
            
        }).WithOpenApi().RequireAuthorization();
        
        
        app.MapGet("/api/Race/RaceCards/{total:int?}", async (int? total) =>
            {
                using var scope = app.Services.CreateScope();
                var raceRepository = scope.ServiceProvider.GetRequiredService<IRaceRepository>();

                var races = (await raceRepository.GetDetailedRaces(total)).ToList();

                var racesViewModel = races.Select(race => race.MapToRaceCardViewModel(mapper));
                
                return Results.Ok(racesViewModel);
            })
            .WithOpenApi();
    }
}