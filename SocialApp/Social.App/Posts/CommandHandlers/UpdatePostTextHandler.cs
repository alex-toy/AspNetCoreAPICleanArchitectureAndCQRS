using Social.Application.Enums;
using Social.Application.Models;
using Social.Application.Posts.Commands;
using Microsoft.EntityFrameworkCore;
using Social.Dal;
using Social.Domain.Aggregates.PostAggregate;
using Social.Domain.Exceptions;

namespace Social.Application.Posts.CommandHandlers;

public class UpdatePostTextHandler : IRequestHandler<UpdatePostText, OperationResult<Post>>
{
    private readonly DataContext _ctx;

    public UpdatePostTextHandler(DataContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<OperationResult<Post>> Handle(UpdatePostText request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Post>();

        try
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken: cancellationToken);
            
            if (post is null)
            {
                result.AddError(ErrorCode.NotFound, 
                    string.Format(PostsErrorMessages.PostNotFound, request.PostId));
                return result;
            }

            if (post.UserProfileId != request.UserProfileId)
            {
                result.AddError(ErrorCode.PostUpdateNotPossible, PostsErrorMessages.PostUpdateNotPossible);
                return result;
            }
            
            post.UpdatePostText(request.NewText);

            await _ctx.SaveChangesAsync(cancellationToken);

            result.Payload = post;
        }
        
        catch (PostNotValidException e)
        {
            e.ValidationErrors.ForEach(er => result.AddError(ErrorCode.ValidationError, er));
        }
        catch (Exception e)
        {
            result.AddUnknownError(e.Message);
        }

        return result;
    }
}