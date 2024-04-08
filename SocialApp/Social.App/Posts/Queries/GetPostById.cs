using Cwk.Domain.Aggregates.PostAggregate;
using Social.Application.Models;
using MediatR;

namespace Social.Application.Posts.Queries;

public class GetPostById : IRequest<OperationResult<Post>>
{
    public Guid PostId { get; set; }
}