using FluentValidation;
using FluentValidation.Results;
using Social.Domain.Aggregates.Friendships;

namespace Social.Domain.Validators.FriendshipsValidators;

public class FriendRequestValidator : AbstractValidator<FriendRequest>
{
    public FriendRequestValidator()
    {
        RuleFor(x => x.FriendRequestId)
            .Custom((id, context) =>
            {
                if (id == Guid.Empty)
                    context.AddFailure(new ValidationFailure("FriendRequestId", "Friend request id is not a valid GUID format"));
            });
        RuleFor(x => x.DateSent).LessThanOrEqualTo(DateTime.Now);
    }
}