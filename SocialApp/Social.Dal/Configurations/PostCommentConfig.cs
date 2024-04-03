using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Domain.Aggregates.PostAggregate;

namespace Social.Dal.Configurations;

internal class PostCommentConfig : IEntityTypeConfiguration<PostComment>
{
    public void Configure(EntityTypeBuilder<PostComment> builder)
    {
        builder.HasKey(pc => pc.CommentId);
    }
}
