using Cwk.Domain.Aggregates.PostAggregate;
using Social.Application.Models;
using MediatR;

namespace Social.Application.Posts.Commands;

public class UpdatePostComment : IRequest<OperationResult<PostComment>>
{
    public Guid UserProfileId { get; set; }
    public Guid PostId { get; set; }
    public Guid CommentId { get; set; }
    public string UpdatedText { get; set; }
}