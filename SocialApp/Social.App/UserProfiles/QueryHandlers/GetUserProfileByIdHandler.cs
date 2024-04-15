using Social.Application.UserProfiles.Queries;
using Social.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Social.Application.Enums;
using Social.Application.Models;
using Social.Application.UserProfiles.Models;
using Social.Domain.Aggregates.UserProfileAggregate;

namespace Social.Application.UserProfiles.QueryHandlers
{
    internal class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileById, OperationResult<UserProfileDto>>
    {
        private readonly DataContext _context;

        public GetUserProfileByIdHandler(DataContext ctx)
        {
            _context = ctx;
        }
        
        public async Task<OperationResult<UserProfileDto>> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfileDto>();

            UserProfile? profile = await _context.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId, cancellationToken);
            
            if (profile is null)
            {
                result.AddError(ErrorCode.NotFound, string.Format(UserProfilesErrorMessages.UserProfileNotFound, request.UserProfileId));
                return result;
            }

            var friendRequests = await _context.FriendRequests
                .Where(fr => fr.ReceiverUserProfileId == request.UserProfileId)
                .ToListAsync();

            var friendships = await _context.Friendships
                .Where(f => f.FirstFriendUserProfileId == request.UserProfileId || f.SecondFriendUserProfileId == request.UserProfileId)
                .ToListAsync();
            
            result.Payload = UserProfileDto.FromUserProfile(profile, friendRequests, friendships);
            return result;
        }
    }
}
