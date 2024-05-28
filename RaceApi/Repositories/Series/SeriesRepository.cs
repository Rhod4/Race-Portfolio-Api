using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaceApi.Models.Dto;
using RaceApi.Persistence;
using RaceApi.Repositories.Series.Interfaces;

namespace RaceApi.Repositories.Series;

public class SeriesRepository: ISeriesRepository
{
    private RaceProjectContext _db;
    private IMapper _mapper;

    public SeriesRepository(RaceProjectContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SeriesDto>> GetSeries()
    {
        var series = await _db.Series.ToListAsync();

        return series.Select(_mapper.Map<SeriesDto>);
    }

    public async Task<SeriesDto> GetSingleSeriesById(Guid id)
    {
        var series = await _db.Series
            .SingleAsync(s => s.Id == id);

        return _mapper.Map<SeriesDto>(series);
    }

    public async Task<IEnumerable<SeriesDto>> GetSeriesByGame(Guid gameId)
    {
        var series = await _db.Series
            .Include(s => s.GamesSeries)
            .Where(s => s.GamesSeries.Any(gs => gs.GameId == gameId))
            .ToListAsync();

        return series.Select(_mapper.Map<SeriesDto>);
    }
}