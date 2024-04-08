using Social.Application.Identity.Dtos;
using Social.Application.Models;
using MediatR;

namespace Social.Application.Identity.Commands;

public class LoginCommand : IRequest<OperationResult<IdentityUserProfileDto>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}