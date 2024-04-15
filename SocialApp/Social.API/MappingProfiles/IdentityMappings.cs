using AutoMapper;
using Social.API.Contracts.Identity;
using Social.Application.Identity.Commands;
using Social.Application.Identity.Dtos;

namespace Social.API.MappingProfiles;

public class IdentityMappings : Profile
{
    public IdentityMappings()
    {
        CreateMap<UserRegistration, RegisterIdentity>();
        CreateMap<Login, LoginCommand>();
        CreateMap<IdentityUserProfileDto, IdentityUserProfile>();
    }
}