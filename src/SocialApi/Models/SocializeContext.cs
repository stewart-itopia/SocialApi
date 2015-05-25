using System.Data.Entity;

namespace SocialApi.Models
{
  public class SocializeContext : DbContext
  {
    public SocializeContext() :
      base("DefaultConnection")
    {
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Connection> Connections { get; set; }
    public DbSet<Invite> Invites { get; set; }
    public DbSet<RateCode> RateCodes { get; set; }
    public DbSet<UserProfile> Profiles { get; set; }
    public DbSet<UserStatus> UserStatuses { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //base.OnModelCreating(modelBuilder);
    }

    public DbSet<Comment> Comments { get; set; }
  }
}