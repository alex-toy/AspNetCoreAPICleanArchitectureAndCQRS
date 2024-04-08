using Cwk.Domain.Aggregates.PostAggregate;
using Social.Application.Models;
using MediatR;

namespace Social.Application.Posts.Queries;

public class GetPostComments : IRequest<OperationResult<List<PostComment>>>
{
    public Guid PostId { get; set; }
}