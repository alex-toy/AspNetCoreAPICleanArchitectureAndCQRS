using Social.Application.Models;
using MediatR;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Application.Posts.Commands;

public class CreatePost : IRequest<OperationResult<Post>>
{
    public Guid UserProfileId { get; set; }
    public string TextContent { get; set; }
}