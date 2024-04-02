using Social.Domain.Exceptions;
using Social.Domain.Validators.PostValidators;

namespace Social.Domain.Aggregates.PostAggregate;

public class PostComment
{
    public Guid CommentId { get; private set; }
    public Guid PostId { get; private set; }
    public string Text { get; private set; }
    public Guid UserProfileId { get; private set; }
    public DateTime DateCreated { get; private set; }
    public DateTime LastModified { get; private set; }

    private PostComment()
    {
    }

    public static PostComment CreatePostComment(Guid postId, string text, Guid userProfileId)
    {
        var validator = new PostCommentValidator();
        var objectToValidate = new PostComment
        {
            PostId = postId,
            Text = text,
            UserProfileId = userProfileId,
            DateCreated = DateTime.UtcNow,
            LastModified = DateTime.UtcNow
        };

        //var validationResult = validator.Validate(objectToValidate);

        //if (validationResult.IsValid) return objectToValidate;

        //var exception = new PostCommentNotValidException("Post comment is not valid");

        //validationResult.Errors.ForEach(vr => exception.ValidationErrors.Add(vr.ErrorMessage));
        //throw exception;

        return objectToValidate;
    }

    public void UpdateCommentText(string newText)
    {
        Text = newText;
        LastModified = DateTime.UtcNow;
    }
}
