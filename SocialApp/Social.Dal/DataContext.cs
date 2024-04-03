using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Social.Dal.Configurations;
using Social.Domain.Aggregates.PostAggregate;
using Social.Domain.Aggregates.UserProfileAggregate;

namespace Social.Dal;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserProfile> userProfiles { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PostCommentConfig());
        builder.ApplyConfiguration(new PostInteractionConfig());
        builder.ApplyConfiguration(new UserProfileConfig());
    }
}
