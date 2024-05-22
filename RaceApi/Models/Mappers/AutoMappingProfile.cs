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
        // Map Race entity to RaceDto
        CreateMap<Race, RaceDto>()
            .ForMember(dest => dest.Game, opt => opt.MapFrom(src => src.Game))
            .ForMember(dest => dest.Track, opt => opt.MapFrom(src => src.Track))
            .ForMember(dest => dest.RaceParticipants, opt => opt.MapFrom(src => src.RaceParticipants))
            .ForMember(dest => dest.RaceMarshel, opt => opt.MapFrom(src => src.RaceMarshel))
            .ForMember(dest => dest.RaceSeries, opt => opt.MapFrom(src => src.RaceSeries));

        // Map nested objects
        CreateMap<Game, GameDto>();
        CreateMap<Track, TrackDto>();
        CreateMap<RaceParticipants, RaceParticipantsDto>()
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
            .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car));
        CreateMap<RaceMarshel, RaceMarshelDto>()
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile));
        CreateMap<RaceSeries, RaceSeriesDto>();
        CreateMap<Cars, CarsDto>();
        CreateMap<Profile, ProfileDto>();
        
        CreateMap<RaceDto, RaceViewModel>()
            .ForMember(dest => dest.Game, opt => opt.MapFrom(src => src.Game))
            .ForMember(dest => dest.Track, opt => opt.MapFrom(src => src.Track))
            .ForMember(dest => dest.RaceParticipants, opt => opt.MapFrom(src => src.RaceParticipants))
            .ForMember(dest => dest.RaceMarshel, opt => opt.MapFrom(src => src.RaceMarshel))
            .ForMember(dest => dest.RaceSeries, opt => opt.MapFrom(src => src.RaceSeries));

        // Map nested objects
        CreateMap<GameDto, GameViewModel>();
        CreateMap<TrackDto, TrackViewModel>();
        CreateMap<RaceParticipantsDto, RaceParticipantsViewModel>()
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
            .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car));
        CreateMap<RaceMarshelDto, RaceMarshelViewModel>()
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile));
        CreateMap<RaceSeriesDto, RaceSeriesViewModel>();
        CreateMap<CarsDto, CarsViewModel>();
        CreateMap<ProfileDto, ProfileViewModel>();
    }
}
