using Social.Application.Models;
using MediatR;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Application.Posts.Queries;

public class GetPostInteractions : IRequest<OperationResult<List<PostInteraction>>>
{
    public Guid PostId { get; set; }
}