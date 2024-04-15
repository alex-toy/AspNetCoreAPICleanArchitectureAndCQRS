using System.ComponentModel.DataAnnotations;

namespace Social.API.Contracts.Posts.Requests;

public class PostUpdate
{
    [Required]
    public string Text { get; set; }
}