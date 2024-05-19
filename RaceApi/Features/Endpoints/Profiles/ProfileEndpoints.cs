using Microsoft.AspNetCore.Identity;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Profiles.Interfaces;

namespace RaceApi.Features.ApiMaps.Profiles;

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

                var profile = await profileRepository.GetProfile(user.Id);
                
                return Results.Ok(new {profile = profile});
            })
            .WithOpenApi()
            .RequireAuthorization();
    }
}