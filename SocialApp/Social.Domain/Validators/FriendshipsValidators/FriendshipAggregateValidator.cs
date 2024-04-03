using Cwk.Domain.Exceptions;
using Social.Domain.Aggregates.Friendships;

namespace Social.Domain.Validators.FriendshipsValidators;

public class FriendshipAggregateValidator
{
    public static void ValidateFriendRequest(FriendRequest friendRequest)
    {
        var validator = new FriendRequestValidator();
        var validationResult = validator.Validate(friendRequest);

        if (!validationResult.IsValid)
            ThrowNotValidException<FriendRequestValidationException>(validationResult.Errors);
    }

    private static void ThrowNotValidException<T>(List<ValidationFailure> errors) where T : DomainModelInvalidException
    {
        var exception = new FriendRequestValidationException("Friend request is not  valid");
        errors
            .ForEach(e => exception.ValidationErrors.Add(e.ErrorMessage));
        throw exception;
    }
}