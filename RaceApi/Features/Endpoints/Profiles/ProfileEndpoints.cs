using Microsoft.AspNetCore.Identity;
using RaceApi.Models.Dto;
using RaceApi.Models.Mappers;
using RaceApi.Models.ViewModels;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Profiles.Interfaces;

namespace RaceApi.Features.Endpoints.Profiles;

public class ProfileEndpoints
{
    public static void Map(WebApplication app)
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
                
                return Results.Ok(new {profile = profile});
            })
            .WithOpenApi()
            .RequireAuthorization();

        app.MapPost("/api/auth/ProfileDetails", async (ProfileDetailsViewModel personalDetails, HttpContext httpContext) =>
        {
            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<Profile>>();
            var user = await userManager.GetUserAsync(httpContext.User);
            
            if (user == null)
                return Results.BadRequest("Error getting details");
            
            using var scope = app.Services.CreateScope();
            var profileRepository = scope.ServiceProvider.GetRequiredService<IProfileRepository>();

            var personalDetailsDto = personalDetails.MapToProfileDetailsDto(user.Id);
            
            var response = await profileRepository.AddUserDetailsToDatabase(personalDetailsDto);

            if (response == null)
            {
                return Results.BadRequest("Error Updating");
            }

            return Results.Ok("Successfully Updated");
        });
    }
}