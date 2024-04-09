using Social.Application.Models;
using MediatR;
using Social.Domain.Aggregates.UserProfileAggregate;


namespace Social.Application.UserProfiles.Queries
{
    public class GetAllUserProfiles : IRequest<OperationResult<IEnumerable<UserProfile>>>
    {
    }
}
