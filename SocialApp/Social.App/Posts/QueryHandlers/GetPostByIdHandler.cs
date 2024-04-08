using Social.Application.Enums;
using Social.Application.Models;
using Social.Application.Posts.Queries;
using Microsoft.EntityFrameworkCore;
using Social.Dal;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Application.Posts.QueryHandlers;

public class GetPostByIdHandler : IRequestHandler<GetPostById, OperationResult<Post>>
{
    private readonly DataContext _ctx;
    public GetPostByIdHandler(DataContext ctx)
    {
        _ctx = ctx;
    }
    public async Task<OperationResult<Post>> Handle(GetPostById request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Post>();
        var post = await _ctx.Posts
            .FirstOrDefaultAsync(p => p.PostId == request.PostId);
            
        if (post is null)
        {
            result.AddError(ErrorCode.NotFound, 
                string.Format(PostsErrorMessages.PostNotFound, request.PostId));
            return result;
        }

        result.Payload = post;
        return result;
    }
}