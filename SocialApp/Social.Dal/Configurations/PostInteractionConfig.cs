using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Dal.Configurations;

internal class PostInteractionConfig : IEntityTypeConfiguration<PostInteraction>
{
    public void Configure(EntityTypeBuilder<PostInteraction> builder)
    {
        builder.HasKey(pi => pi.InteractionId);
    }
}
