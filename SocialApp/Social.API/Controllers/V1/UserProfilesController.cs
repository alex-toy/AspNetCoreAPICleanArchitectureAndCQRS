using Microsoft.AspNetCore.Mvc;
using Social.API.Contracts.UserProfile.Requests;
using Social.API.Contracts.UserProfile.Responses;
using Social.Application.Models;
using Social.Application.UserProfiles.Commands;
using Social.Application.UserProfiles.Models;
using Social.Application.UserProfiles.Queries;
using Social.Domain.Aggregates.UserProfileAggregate;

namespace Social.API.Controllers.V1;


//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserProfilesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllProfiles(CancellationToken cancellationToken)
    {
        var query = new GetAllUserProfiles();
        var response = await _mediator.Send(query, cancellationToken);
        var profiles = _mapper.Map<List<UserProfileResponse>>(response.Payload);
        return Ok(profiles);
    }

    [Route(ApiRoutes.UserProfiles.IdRoute)]
    [HttpGet]
    //[ValidateGuid("id")]
    public async Task<IActionResult> GetUserProfileById(string id, CancellationToken cancellationToken)
    {
        var query = new GetUserProfileById { UserProfileId = Guid.Parse(id) };
        OperationResult<UserProfileDto> response = await _mediator.Send(query, cancellationToken);

        if (response.IsError) return HandleErrorResponse(response.Errors);

        UserProfileResponse userProfile = UserProfileResponse.FromUserProfileDto(response.Payload);
        return Ok(userProfile);
    }

    [HttpPatch]
    [Route(ApiRoutes.UserProfiles.IdRoute)]
    //[ValidateModel]
    //[ValidateGuid("id")]
    public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdate updatedProfile, CancellationToken cancellationToken)
    {
        UpdateUserProfileBasicInfo command = _mapper.Map<UpdateUserProfileBasicInfo>(updatedProfile);
        command.UserProfileId = Guid.Parse(id);
        OperationResult<UserProfile> response = await _mediator.Send(command, cancellationToken);

        return response.IsError ? HandleErrorResponse(response.Errors) : NoContent();
    }
}
