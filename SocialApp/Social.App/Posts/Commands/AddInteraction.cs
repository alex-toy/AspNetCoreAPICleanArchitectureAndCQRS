using Social.Application.Models;
using MediatR;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Application.Posts.Commands;

public class AddInteraction : IRequest<OperationResult<PostInteraction>>
{
    public Guid PostId { get; set; }
    public Guid UserProfileId { get; set; }
    public InteractionType Type { get; set; }
}