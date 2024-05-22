using RaceApi.Models.Dto;
using RaceApi.Models.ViewModels;

namespace RaceApi.Models.Mappers;

public static class ProfileDetailsMapper
{
    public static ProfileDetailsViewModel MapToProfileDetailsViewModel(this ProfileDetailsDto profileDetailsDto)
    {
        return new ProfileDetailsViewModel
        {
            Firstname = profileDetailsDto.Firstname,
            Lastname = profileDetailsDto.Lastname,
            Email = profileDetailsDto.Email
        };
    }
    public static ProfileDetailsDto MapToProfileDetailsDto(this ProfileDetailsViewModel profileDetailsDto, string userId)
    {
        return new ProfileDetailsDto
        {
            UserId = userId,
            Firstname = profileDetailsDto.Firstname,
            Lastname = profileDetailsDto.Lastname,
            Email = profileDetailsDto.Email
        };
    }
    
}