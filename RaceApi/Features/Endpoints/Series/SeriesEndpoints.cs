using AutoMapper;
using RaceApi.Models.ViewModels;
using RaceApi.Repositories.Series.Interfaces;

namespace RaceApi.Features.Endpoints.Series;

public static class SeriesEndpoints
{
    
    public static void Map(WebApplication app, IMapper mapper)
    {
        app.MapGet("/api/Series/GetSeries", async () =>
        {
            
        });
        app.MapGet("/api/Series/GetSeriesByGame/{gameId:guid}", async (Guid gameId) =>
        {
            using var scope = app.Services.CreateScope();
            var seriesRepository = scope.ServiceProvider.GetRequiredService<ISeriesRepository>();

            var seriesDtos = await seriesRepository.GetSeriesByGame(gameId);

            return Results.Ok(seriesDtos.Select(mapper.Map<SeriesViewModel>));
        });

    }
}