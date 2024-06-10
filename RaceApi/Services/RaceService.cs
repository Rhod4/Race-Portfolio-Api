using AutoMapper;
using RaceApi.Models.Dto;
using RaceApi.Models.Dto.Races;
using RaceApi.Models.Requests;
using RaceApi.Persistence.Models;
using RaceApi.Repositories.Games.Interfaces;
using RaceApi.Repositories.Races.Interfaces;
using RaceApi.Repositories.RaceSeries.Interfaces;
using RaceApi.Repositories.Series.Interfaces;
using RaceApi.Repositories.Tracks.Interfaces;
using RaceApi.Services.Interfaces;
using Profile = RaceApi.Persistence.Models.Profile;

namespace RaceApi.Services;

public class RaceService : ICreateRaceService
{
    private IRaceRepository _raceRepository;
    private ISeriesRepository _seriesRepository;
    private ITrackRepository _trackRepository;
    private IGameRepository _gameRepository;
    private IMapper _mapper;
    private IRaceSeriesRepository _raceSeriesRepository;

    public RaceService(IRaceRepository raceRepository, ISeriesRepository seriesRepository, 
        ITrackRepository trackRepository, IGameRepository gameRepository,
        IMapper mapper, IRaceSeriesRepository raceSeriesRepository)
    {
        _raceRepository = raceRepository;
        _seriesRepository = seriesRepository;
        _trackRepository = trackRepository;
        _gameRepository = gameRepository;
        _mapper = mapper;
        _raceSeriesRepository = raceSeriesRepository;
    }

    public async Task<RaceDto> CreateCompleteRaceByGame(CreateRaceRequest createRaceRequest, Profile profile)
    {
        var gameDto = await _gameRepository.GetGamesById(createRaceRequest.GameId);
        var trackDto = await _trackRepository.GetTrackById(createRaceRequest.TrackId);
        var seriesDto = await _seriesRepository.GetSingleSeriesById(createRaceRequest.SeriesId);
        
        var series = _mapper.Map<Series>(seriesDto);
        
        var createdRace = new CreateOrEditRace
        {
            Id = new Guid() ,
            Name = createRaceRequest.Name,
            CreatedOn = DateTime.Now,
            CreatedBy = profile,
            RaceDate = createRaceRequest.RaceDate,
            Game = gameDto,
            Track = trackDto
        };

        var race = await _raceRepository.CreateCompleteRace(createdRace);

        await _raceSeriesRepository.CreateSeries(series, _mapper.Map<Race>(race));

        return race;
    }
    
    public async Task<RaceDto> EditCompleteRaceByGame(CreateRaceRequest createRaceRequest, Profile profile)
    {
        var gameDto = await _gameRepository.GetGamesById(createRaceRequest.GameId);
        var trackDto = await _trackRepository.GetTrackById(createRaceRequest.TrackId);
        var seriesDto = await _seriesRepository.GetSingleSeriesById(createRaceRequest.SeriesId);
        
        var series = _mapper.Map<Series>(seriesDto);
        
        var createdRace = new CreateOrEditRace
        {
            Id = Guid.Parse(createRaceRequest.Id!),
            Name = createRaceRequest.Name,
            CreatedOn = DateTime.Now,
            CreatedBy = profile,
            RaceDate = createRaceRequest.RaceDate,
            Game = gameDto,
            Track = trackDto
        };
        
        var race = await _raceRepository.UpdateCompleteRace(createdRace);

        await _raceSeriesRepository.UpdateSeries(series, _mapper.Map<Race>(race));

        return race;
    }
}