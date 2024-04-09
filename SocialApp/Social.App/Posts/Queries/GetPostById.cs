using Social.Application.Models;
using MediatR;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Application.Posts.Queries;

public class GetPostById : IRequest<OperationResult<Post>>
{
    public Guid PostId { get; set; }
}