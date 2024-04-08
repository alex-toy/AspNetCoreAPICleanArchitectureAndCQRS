using Social.Application.Models;
using MediatR;

namespace Social.Application.Identity.Commands;

public class RemoveAccount : IRequest<OperationResult<bool>>
{
    public Guid IdentityUserId { get; set; }
    public Guid RequestorGuid { get; set; }
}