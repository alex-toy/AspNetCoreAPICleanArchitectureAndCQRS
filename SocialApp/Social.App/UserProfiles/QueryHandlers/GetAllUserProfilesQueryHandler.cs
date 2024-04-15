using Social.Application.Models;
using Social.Application.UserProfiles.Queries;
using Microsoft.EntityFrameworkCore;
using Social.Dal;
using Social.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace Social.Application.UserProfiles.QueryHandlers
{
    internal class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfiles, OperationResult<IEnumerable<UserProfile>>>
    {
        private readonly DataContext _context;

        public GetAllUserProfilesQueryHandler(DataContext ctx)
        {
            _context = ctx;
        }
        
        public async Task<OperationResult<IEnumerable<UserProfile>>> Handle(GetAllUserProfiles request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<UserProfile>>();
            result.Payload =  await _context.UserProfiles.ToListAsync(cancellationToken);
            return result;
        }
    }
}
