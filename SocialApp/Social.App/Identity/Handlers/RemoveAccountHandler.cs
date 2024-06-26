﻿using Social.Application.Enums;
using Social.Application.Identity.Commands;
using Social.Application.Models;
using Social.Application.UserProfiles;
using Microsoft.EntityFrameworkCore;
using Social.Dal;
using MediatR;

namespace Social.Application.Identity.Handlers;

public class RemoveAccountHandler : IRequestHandler<RemoveAccount, OperationResult<bool>>
{
    private readonly DataContext _ctx;

    public RemoveAccountHandler(DataContext ctx)
    {
        _ctx = ctx;
    }
    public async Task<OperationResult<bool>> Handle(RemoveAccount request, 
        CancellationToken cancellationToken)
    {
        var result = new OperationResult<bool>();

        try
        {
            var identityUser = await _ctx.Users.FirstOrDefaultAsync(iu 
                => iu.Id == request.IdentityUserId.ToString(), cancellationToken);

            if (identityUser == null)
            {
                result.AddError(ErrorCode.IdentityUserDoesNotExist, 
                    IdentityErrorMessages.NonExistentIdentityUser);
                return result;
            }

            var userProfile = await _ctx.UserProfiles
                .FirstOrDefaultAsync(up
                    => up.IdentityId == request.IdentityUserId.ToString(), cancellationToken);

            if (userProfile == null)
            {
                result.AddError(ErrorCode.NotFound, UserProfilesErrorMessages.UserProfileNotFound);
                return result;
            }

            if (identityUser.Id != request.RequestorGuid.ToString())
            {
                result.AddError(ErrorCode.UnauthorizedAccountRemoval, 
                    IdentityErrorMessages.UnauthorizedAccountRemoval);

                return result;
            }

            _ctx.UserProfiles.Remove(userProfile);
            _ctx.Users.Remove(identityUser);
            await _ctx.SaveChangesAsync(cancellationToken);

            result.Payload = true;
        }
        catch (Exception e)
        {
            result.AddUnknownError(e.Message);
        }

        return result;
    }
}