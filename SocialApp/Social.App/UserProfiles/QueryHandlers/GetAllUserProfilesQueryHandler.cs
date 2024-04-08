using Social.Application.Models;
using Social.Application.UserProfiles.Queries;
using Microsoft.EntityFrameworkCore;
using Social.Dal;

namespace Social.Application.UserProfiles.QueryHandlers
{
    internal class GetAllUserProfilesQueryHandler 
        : IRequestHandler<GetAllUserProfiles, OperationResult<IEnumerable<UserProfile>>>
    {
        private readonly DataContext _ctx;
        public GetAllUserProfilesQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<OperationResult<IEnumerable<UserProfile>>> Handle(GetAllUserProfiles request, 
            CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<UserProfile>>();
            result.Payload =  await _ctx.UserProfiles.ToListAsync(cancellationToken: cancellationToken);
            return result;
        }
    }
}
