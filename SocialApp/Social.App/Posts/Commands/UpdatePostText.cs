using Social.Application.Models;
using MediatR;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Application.Posts.Commands;

public class UpdatePostText : IRequest<OperationResult<Post>>
{
    public string NewText { get; set; }
    public Guid PostId { get; set; }
    public Guid UserProfileId { get; set; }
}