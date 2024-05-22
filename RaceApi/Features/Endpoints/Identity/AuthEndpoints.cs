using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RaceApi.Models.Dto;
using RaceApi.Models.ViewModels;
using RaceApi.Persistence.Models;

namespace RaceApi.Features.Endpoints.Identity;

public static class AuthEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapPost("/api/auth/logout", async (SignInManager<Profile> signInManager,
                [FromBody] object empty) =>
            {
                if (empty != null)
                {
                    await signInManager.SignOutAsync();
                    return Results.Ok();
                }
                return Results.Unauthorized();
            })
            .WithOpenApi()
            .RequireAuthorization();
    }
    
}