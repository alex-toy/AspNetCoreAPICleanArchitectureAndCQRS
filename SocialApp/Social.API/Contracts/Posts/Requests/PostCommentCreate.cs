using System.ComponentModel.DataAnnotations;

namespace Social.API.Contracts.Posts.Requests;

public class PostCommentCreate
{
    [Required]
    public string Text { get; set; }

}