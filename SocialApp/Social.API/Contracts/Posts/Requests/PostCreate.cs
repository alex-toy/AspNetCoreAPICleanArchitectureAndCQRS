using System.ComponentModel.DataAnnotations;

namespace Social.API.Contracts.Posts.Requests;

public class PostCreate
{
    [Required]
    public string TextContent { get; set; }
}