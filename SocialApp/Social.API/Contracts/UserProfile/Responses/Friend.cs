using Social.Application.UserProfiles.Models;

namespace Social.API.Contracts.UserProfile.Responses;

public class Friend
{
    public Guid FriendshipId { get; set; }
    public string? FriendFullName { get; set; }
    public string? City { get; set; }

    public static Friend FromFriendDto(FriendDto friendDto)
    {
        return new Friend
        {
            FriendshipId = friendDto.FriendshipId,
            FriendFullName = friendDto.FriendFullName,
            City = friendDto.City
        };
    }
}