using Social.Application.Models;
using Social.Application.UserProfiles.Models;
using MediatR;

namespace Social.Application.UserProfiles.Queries
{
    public class GetUserProfileById : IRequest<OperationResult<UserProfileDto>>
    {
        public Guid UserProfileId { get; set; }
    }
}
