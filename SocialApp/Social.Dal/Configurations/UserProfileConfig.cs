using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Domain.Aggregates.UserProfileAggregate;

namespace Social.Dal.Configurations;

internal class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.OwnsOne(up => up.BasicInfo);
    }
}
