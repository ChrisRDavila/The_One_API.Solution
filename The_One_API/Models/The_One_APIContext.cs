using Microsoft.EntityFrameworkCore;

namespace The_One_API.Models
{
  public class The_One_APIContext : DbContext
  {
    public DbSet<Tweet> Tweets { get; set; }

    public The_One_APIContext(DbContextOptions<The_One_APIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Tweet>()
          .HasIndex(t => t.TweetId);
    }
  }
}