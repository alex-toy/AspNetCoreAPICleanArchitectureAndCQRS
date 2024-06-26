﻿using Social.Application.Enums;
using Social.Application.Models;
using Social.Application.Posts.Commands;
using Microsoft.EntityFrameworkCore;
using Social.Dal;
using Social.Domain.Aggregates.PostAggregate;
using MediatR;

namespace Social.Application.Posts.CommandHandlers;

public class RemoveCommentFromPostHandler : IRequestHandler<RemoveCommentFromPost, OperationResult<PostComment>>
{
    private readonly DataContext _ctx;
    private readonly OperationResult<PostComment> _result;

    public RemoveCommentFromPostHandler(DataContext ctx)
    {
        _ctx = ctx;
        _result = new OperationResult<PostComment>();
    }
    
    public async Task<OperationResult<PostComment>> Handle(RemoveCommentFromPost request, 
        CancellationToken cancellationToken)
    {
        var post = await _ctx.Posts
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken);

        if (post == null)
        {
            _result.AddError(ErrorCode.NotFound, PostsErrorMessages.PostNotFound);
            return _result;
        }

        var comment = post.Comments
            .FirstOrDefault(c => c.CommentId == request.CommentId);
        if (comment == null)
        {
            _result.AddError(ErrorCode.NotFound, PostsErrorMessages.PostCommentNotFound);
            return _result;
        }

        if (comment.UserProfileId != request.UserProfileId)
        {
            _result.AddError(ErrorCode.CommentRemovalNotAuthorized, 
                PostsErrorMessages.CommentRemovalNotAuthorized);
            return _result;
        }
        
        post.RemoveComment(comment);
        _ctx.Posts.Update(post);
        await _ctx.SaveChangesAsync(cancellationToken);

        _result.Payload = comment;
        return _result;
    }
}