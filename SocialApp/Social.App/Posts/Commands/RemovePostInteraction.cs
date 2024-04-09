using Social.Application.Models;
using MediatR;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Application.Posts.Commands;

public class RemovePostInteraction : IRequest<OperationResult<PostInteraction>>
{
    public Guid PostId { get; set; }
    public Guid InteractionId { get; set; }
    public Guid UserProfileId { get; set; }
}