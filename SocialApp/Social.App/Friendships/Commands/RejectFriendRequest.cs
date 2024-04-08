using Social.Application.Enums;
using Social.Application.Models;
using Microsoft.EntityFrameworkCore;
using Social.Dal;

namespace Social.Application.Friendships.Commands;

public class RejectFriendRequest : IRequest<OperationResult<Unit>>
{
    public Guid FriendRequestId { get; set; }
    public Guid ActionPerformedById { get; set; }
}

public class RejectFriendRequestHandler : IRequestHandler<RejectFriendRequest, OperationResult<Unit>>
{
    private readonly DataContext _ctx;
    private readonly OperationResult<Unit> _result = new();

    public RejectFriendRequestHandler(DataContext ctx)
    {
        _ctx = ctx;
    }
    public async Task<OperationResult<Unit>> Handle(RejectFriendRequest request, 
        CancellationToken cancellationToken)
    {
        var friendRequest = await _ctx.FriendRequests
            .FirstOrDefaultAsync(fr 
                => fr.FriendRequestId == request.FriendRequestId && 
                   fr.ReceiverUserProfileId == request.ActionPerformedById, cancellationToken);

        if (friendRequest is null)
        {
            _result.AddError(ErrorCode.FriendRequestRejectNotPossible, 
                "Not possible to reject friend request");
            return _result;
        }

        friendRequest.RejectFriendRequest();
        
        _ctx.FriendRequests.Update(friendRequest);

        try
        {
            await _ctx.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _result.AddError(ErrorCode.DatabaseOperationException, e.Message);
        }

        return _result;
    }
}