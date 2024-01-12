using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using Twitter.Core.Entities;
using Twitter.Core.Entities.Common;

namespace Twitter.DAL.Contexts;

public class TwitterContext : IdentityDbContext
{
    public TwitterContext(DbContextOptions opt) : base(opt)
    {
    }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostReaction> PostReactions { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            if(entry.State == EntityState.Added)
                entry.Entity.CreatedTime = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TopicConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<IdentityUser>().Ignore(b => b.PhoneNumber)
        .Ignore(b => b.PhoneNumberConfirmed);
        base.OnModelCreating(modelBuilder);
    }
}
