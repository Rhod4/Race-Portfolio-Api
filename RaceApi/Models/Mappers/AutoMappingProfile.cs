using AutoMapper;
using RaceApi.Models.Dto;
using RaceApi.Models.ViewModels;
using RaceApi.Persistence.Models;
using Profile = AutoMapper.Profile;

namespace RaceApi.Models.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Database model to Dto
        CreateMap<Race, RaceDto>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
            .ForMember(dest => dest.Game, opt => opt.MapFrom(src => src.Game))
            .ForMember(dest => dest.Track, opt => opt.MapFrom(src => src.Track))
            .ForMember(dest => dest.RaceParticipants, opt => opt.MapFrom(src => src.RaceParticipants))
            .ForMember(dest => dest.RaceMarshel, opt => opt.MapFrom(src => src.RaceMarshel))
            .ForMember(dest => dest.RaceSeries, opt => opt.MapFrom(src => src.RaceSeries));

        CreateMap<Game, GameDto>();
        CreateMap<Track, TrackDto>();
        CreateMap<RaceParticipants, RaceParticipantsDto>()
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
            .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car));
        CreateMap<RaceMarshel, RaceMarshelDto>()
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile));
        CreateMap<RaceSeries, RaceSeriesDto>();
        CreateMap<Series, SeriesDto>();
        CreateMap<Cars, CarsDto>();
        CreateMap<RaceApi.Persistence.Models.Profile, ProfileDto>();

        CreateMap<Location, LocationDto>();
        
        //DTO To ViewModel
        CreateMap<RaceDto, RaceViewModel>();
        CreateMap<GameDto, GameViewModel>();
        CreateMap<TrackDto, TrackViewModel>();
        CreateMap<RaceParticipantsDto, RaceParticipantsViewModel>();
        CreateMap<RaceMarshelDto, RaceMarshelViewModel>();
        CreateMap<RaceSeriesDto, RaceSeriesViewModel>();
        CreateMap<CarsDto, CarsViewModel>();
        CreateMap<SeriesDto, SeriesViewModel>();
        CreateMap<ProfileDto, ProfileViewModel>();
        CreateMap<ProfileDto, ProfileDetailsViewModel>();

        //ViewModel To DTO
        CreateMap<RaceViewModel, RaceDto>();
        CreateMap<GameViewModel, GameDto>();
        CreateMap<TrackViewModel, TrackDto>();
        CreateMap<RaceParticipantsViewModel, RaceParticipantsDto>();
        CreateMap<RaceMarshelViewModel, RaceMarshelDto>();
        CreateMap<RaceSeriesViewModel, RaceSeriesDto>();
        CreateMap<CarsViewModel, CarsDto>();
        CreateMap<SeriesViewModel, SeriesDto>();
        CreateMap<ProfileViewModel, ProfileDto>();
        CreateMap<ProfileDetailsViewModel, ProfileDto>()
            .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.Firstname))
            .ForMember(d => d.Lastname, opt => opt.MapFrom(s => s.Lastname));
    }
}
