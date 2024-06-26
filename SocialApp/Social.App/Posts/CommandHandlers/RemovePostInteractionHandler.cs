﻿using Social.Application.Enums;
using Social.Application.Models;
using Social.Application.Posts.Commands;
using Microsoft.EntityFrameworkCore;
using Social.Dal;
using Social.Domain.Aggregates.PostAggregate;
using MediatR;

namespace Social.Application.Posts.CommandHandlers;

public class RemovePostInteractionHandler : IRequestHandler<RemovePostInteraction, OperationResult<PostInteraction>>
{
    private readonly DataContext _ctx;

    public RemovePostInteractionHandler(DataContext ctx)
    {
        _ctx = ctx;
    }
    public async Task<OperationResult<PostInteraction>> Handle(RemovePostInteraction request, 
        CancellationToken cancellationToken)
    {
        var result = new OperationResult<PostInteraction>();
        try
        {
            var post = await _ctx.Posts
                .Include(p => p.Interactions)
                .FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken);

            if (post is null)
            {
                result.AddError(ErrorCode.NotFound,
                    string.Format(PostsErrorMessages.PostNotFound, request.PostId));
                return result;
            }

            var interaction = post.Interactions.FirstOrDefault(i
                => i.InteractionId == request.InteractionId);

            if (interaction == null)
            {
                result.AddError(ErrorCode.NotFound, PostsErrorMessages.PostInteractionNotFound);
                return result;
            }

            if (interaction.UserProfileId != request.UserProfileId)
            {
                result.AddError(ErrorCode.InteractionRemovalNotAuthorized,
                    PostsErrorMessages.InteractionRemovalNotAuthorized);
                return result;
            }
            
            post.RemoveInteraction(interaction);
            _ctx.Posts.Update(post);
            await _ctx.SaveChangesAsync(cancellationToken);

            result.Payload = interaction;
        }
        catch (Exception e)
        {
            result.AddUnknownError(e.Message);
        }

        return result;
    }
}