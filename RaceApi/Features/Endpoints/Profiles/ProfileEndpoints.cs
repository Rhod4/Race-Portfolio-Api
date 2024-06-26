using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RaceApi.Models.Dto;
using RaceApi.Models.Mappers;
using RaceApi.Models.ViewModels;
using RaceApi.Repositories.Profiles.Interfaces;
using Profile = RaceApi.Persistence.Models.Profile;

namespace RaceApi.Features.Endpoints.Profiles;

public static class ProfileEndpoints
{

    public static void Map(WebApplication app, IMapper mapper)
    {
        app.MapGet("/api/Profile/Profile", async (HttpContext httpContext) =>
            {
                var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
                var user = await userManager.GetUserAsync(httpContext.User);

                if (user == null)
                    return Results.BadRequest("Error getting details");
                
                using var scope = app.Services.CreateScope();
                var profileRepository = scope.ServiceProvider.GetRequiredService<IProfileRepository>();

                var profile = await profileRepository.GetProfileById(user.Id);
                
                var profileViewModel = mapper.Map<ProfileViewModel>(profile);
                
                return Results.Ok(profileViewModel);
            })
            .WithOpenApi()
            .RequireAuthorization();

        app.MapPost("/api/Profile/ProfileDetails", async (ProfileDetailsViewModel personalDetails, HttpContext httpContext) =>
        {
            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
            var user = await userManager.GetUserAsync(httpContext.User);
            
            if (user == null)
                return Results.BadRequest("Error getting details");
            
            using var scope = app.Services.CreateScope();
            var profileRepository = scope.ServiceProvider.GetRequiredService<IProfileRepository>();

            var personalDetailsDto = new ProfileDetailsDto
            {
                UserId = user.Id,
                Firstname = personalDetails.Firstname,
                Lastname = personalDetails.Lastname
            };
            
            var profileDto = await profileRepository.AddUserDetailsToDatabase(personalDetailsDto);

            if (profileDto == null)
            {
                return Results.BadRequest("Error Updating");
            }

            var profileViewModel = mapper.Map<ProfileDto, ProfileViewModel>(profileDto);
            
            return Results.Ok(profileViewModel);
        })
        .WithOpenApi()
        .RequireAuthorization();
    }
}