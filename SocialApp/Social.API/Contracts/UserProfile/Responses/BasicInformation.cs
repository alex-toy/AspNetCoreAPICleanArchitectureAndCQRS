using Social.Application.UserProfiles.Models;

namespace Social.API.Contracts.UserProfile.Responses
{
    public record BasicInformation
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CurrentCity { get; set; }

        public static BasicInformation FromUserInfoDto(UserInfoDto infoDto)
        {
            return new BasicInformation
            {
                FirstName = infoDto.FirstName,
                LastName = infoDto.LastName,
                EmailAddress = infoDto.EmailAddress,
                Phone = infoDto.Phone,
                DateOfBirth = infoDto.DateOfBirth,
                CurrentCity = infoDto.CurrentCity
            };
        }
    }
}
