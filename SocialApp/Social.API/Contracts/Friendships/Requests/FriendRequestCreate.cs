using System.ComponentModel.DataAnnotations;

namespace Social.API.Contracts.Friendships.Requests;

public class FriendRequestCreate
{
    [Required]
    public Guid RequesterId { get; set; }

    [Required]
    public Guid ReceiverId { get; set; }
}