using Social.Domain.Aggregates.PostAggregate;
using System.ComponentModel.DataAnnotations;

namespace Social.API.Contracts.Posts.Requests;

public class PostInteractionCreate
{
    [Required]
    public InteractionType Type { get; set; }
}