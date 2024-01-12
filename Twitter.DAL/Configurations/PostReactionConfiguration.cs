using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Core.Entities;

namespace Twitter.DAL.Configurations
{
    public class PostReactionConfiguration : IEntityTypeConfiguration<PostReaction>
    {
        public void Configure(EntityTypeBuilder<PostReaction> builder)
        {
            builder.HasOne(x => x.AppUser)
                .WithMany(au => au.Reactions)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Post)
                .WithMany(p => p.Reactions)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
