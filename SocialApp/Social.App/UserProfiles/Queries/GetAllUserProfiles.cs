using Cwk.Domain.Aggregates.UserProfileAggregate;
using Social.Application.Models;
using MediatR;


namespace Social.Application.UserProfiles.Queries
{
    public class GetAllUserProfiles : IRequest<OperationResult<IEnumerable<UserProfile>>>
    {
    }
}
