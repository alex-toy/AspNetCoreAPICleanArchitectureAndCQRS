using Social.Application.Models;
using MediatR;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Application.Posts.Commands;

public class AddPostComment : IRequest<OperationResult<PostComment>>
{
    public Guid PostId { get; set; }
    public Guid UserProfileId { get; set; }
    public string CommentText { get; set; }
}