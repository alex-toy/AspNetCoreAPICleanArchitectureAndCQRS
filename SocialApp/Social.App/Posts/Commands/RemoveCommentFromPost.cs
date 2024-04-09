using Social.Application.Models;
using MediatR;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Application.Posts.Commands;

public class RemoveCommentFromPost : IRequest<OperationResult<PostComment>>
{
    public Guid UserProfileId { get; set; }
    public Guid PostId { get; set; }
    public Guid CommentId { get; set; }
}