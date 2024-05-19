using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RaceApi.Persistence.Models;

namespace RaceApi.Features.Endpoints.Identity;

public static class AuthEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/api/auth/Test", async (HttpContext httpContext) =>
            {
                return Results.Ok("Logged out successfully");
            })
            .WithOpenApi()
            .RequireAuthorization();
        
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