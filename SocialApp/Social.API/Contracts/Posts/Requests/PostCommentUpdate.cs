using System.ComponentModel.DataAnnotations;

namespace Social.API.Contracts.Posts.Requests;

public class PostCommentUpdate
{
    [Required]
    public string Text { get; set; }
}