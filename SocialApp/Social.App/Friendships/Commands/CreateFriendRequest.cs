using MediatR;
using Social.Application.Enums;
using Social.Application.Models;
using Social.Dal;
using Social.Domain.Aggregates.Friendships;
using Social.Domain.Exceptions;

namespace Social.Application.Friendships.Commands;

public class CreateFriendRequest : IRequest<OperationResult<Unit>>
{
    public Guid RequesterId { get; set; }
    public Guid ReceiverId { get; set; }
}

public class CreateFriendRequestHandler : IRequestHandler<CreateFriendRequest, OperationResult<Unit>>
{
    private readonly DataContext _context;
    private readonly OperationResult<Unit> _result = new();

    public CreateFriendRequestHandler(DataContext ctx)
    {
        _context = ctx;
    }
    public async Task<OperationResult<Unit>> Handle(CreateFriendRequest request, 
        CancellationToken cancellationToken)
    {
        try
        {
            var friendRequest = FriendRequest.CreateFriendRequest(Guid.NewGuid(), request.RequesterId, request.ReceiverId, DateTime.UtcNow);
            _context.FriendRequests.Add(friendRequest);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (FriendRequestValidationException ex)
        {
            _result.AddError(ErrorCode.FriendRequestValidationError, ex.Message);
        }
        catch (Exception e)
        {
            _result.AddError(ErrorCode.DatabaseOperationException, e.Message);
        }
        
        return _result;
    }
}