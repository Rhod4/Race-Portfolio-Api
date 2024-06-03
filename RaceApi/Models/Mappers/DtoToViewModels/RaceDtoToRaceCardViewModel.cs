using AutoMapper;
using RaceApi.Models.Dto;
using RaceApi.Models.ViewModels;
using RaceApi.Models.ViewModels.ManualMapViewModels;

namespace RaceApi.Models.Mappers.DtoToViewModels;

public static class RaceDtoToRaceCardViewModel
{
    public static RaceCardViewModel MapToRaceCardViewModel(this RaceDto raceDto, IMapper mapper)
    {
        if (raceDto.Game?.Name != null && raceDto.Track != null)
            return new RaceCardViewModel
            {
                Id = raceDto.Id,
                Name = raceDto.Name,
                CreatedOn = raceDto.CreatedOn,
                CreatedBy = mapper.Map<ProfileDetailsViewModel>(raceDto.CreatedBy),
                UpdatedOn = raceDto.UpdatedOn,
                RaceDate = raceDto.RaceDate,
                Game = raceDto.Game,
                TrackName = raceDto.Track.Name,
                RaceParticipants = raceDto.RaceParticipants.Count,
                RaceMarshel = raceDto.RaceMarshel.Count,
                RaceSeries = raceDto.RaceSeries.Select(mapper.Map<RaceSeriesViewModel>).ToList()
            };
        return new RaceCardViewModel();
    }
}