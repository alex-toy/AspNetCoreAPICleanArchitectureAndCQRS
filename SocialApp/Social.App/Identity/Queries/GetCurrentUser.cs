using System.Security.Claims;
using Social.Application.Identity.Dtos;
using Social.Application.Models;
using MediatR;

namespace Social.Application.Identity.Queries;

public class GetCurrentUser : IRequest<OperationResult<IdentityUserProfileDto>>
{
    public Guid UserProfileId { get; set; }
    public ClaimsPrincipal ClaimsPrincipal { get; set; }
}