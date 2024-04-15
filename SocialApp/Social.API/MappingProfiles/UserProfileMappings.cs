using AutoMapper;
using Social.API.Contracts.Posts.Responses;
using Social.API.Contracts.UserProfile.Requests;
using Social.API.Contracts.UserProfile.Responses;
using Social.Application.UserProfiles.Commands;
using Social.Domain.Aggregates.UserProfileAggregate;

namespace Social.API.MappingProfiles;

public class UserProfileMappings : Profile
{
    public UserProfileMappings()
    {
        CreateMap<UserProfileCreateUpdate, UpdateUserProfileBasicInfo>();

        CreateMap<UserProfile, UserProfileResponse>();

        CreateMap<BasicInfo, BasicInformation>();

        CreateMap<UserProfile, InteractionUser>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.BasicInfo.FirstName + " " + src.BasicInfo.LastName))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.BasicInfo.CurrentCity));
    }
}
