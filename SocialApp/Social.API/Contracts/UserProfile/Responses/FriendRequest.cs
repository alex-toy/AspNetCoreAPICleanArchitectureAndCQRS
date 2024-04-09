using Social.Application.UserProfiles.Models;

namespace Social.API.Contracts.UserProfile.Responses;

public class FriendRequest
{
    public Guid FriendRequestId { get; set; }
    public string? RequesterFullname { get; set; }
    public string? City { get; set; }

    public static FriendRequest FromFriendRequestDto(FriendRequestDto requestDto)
    {
        return new FriendRequest
        {
            FriendRequestId = requestDto.FriendRequestId,
            RequesterFullname = requestDto.RequesterFullname,
            City = requestDto.City
        };
    }
}