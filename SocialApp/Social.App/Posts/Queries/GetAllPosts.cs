using Cwk.Domain.Aggregates.PostAggregate;
using Social.Application.Models;
using MediatR;

namespace Social.Application.Posts.Queries;

public class GetAllPosts : IRequest<OperationResult<List<Post>>>
{
    
}