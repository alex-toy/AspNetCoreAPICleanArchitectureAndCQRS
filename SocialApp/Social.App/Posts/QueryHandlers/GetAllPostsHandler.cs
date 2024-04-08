using Social.Application.Models;
using Social.Application.Posts.Queries;
using Microsoft.EntityFrameworkCore;
using Social.Dal;

namespace Social.Application.Posts.QueryHandlers;

public class GetAllPostsHandler : IRequestHandler<GetAllPosts, OperationResult<List<Post>>>
{
    private readonly DataContext _ctx;
    public GetAllPostsHandler(DataContext ctx)
    {
        _ctx = ctx;
    }
    public async Task<OperationResult<List<Post>>> Handle(GetAllPosts request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<List<Post>>();
        try
        {
            var posts = await _ctx.Posts.ToListAsync();
            result.Payload = posts;
        }
        catch (Exception e)
        {
            result.AddUnknownError(e.Message);
        }

        return result;
    }
}