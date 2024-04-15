using AutoMapper;
using Social.API.Contracts.Posts.Responses;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.API.MappingProfiles;

public class PostMappings : Profile
{
    public PostMappings()
    {
        CreateMap<Post, PostResponse>();
        CreateMap<PostComment, PostCommentResponse>();
        CreateMap<Contracts.Posts.Responses.PostInteraction, Social.API.Contracts.Posts.Responses.PostInteraction>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author));
    }
}