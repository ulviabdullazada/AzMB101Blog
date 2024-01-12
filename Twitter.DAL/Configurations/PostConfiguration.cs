using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Core.Entities;

namespace Twitter.DAL.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(512);
            builder.Property(x => x.UpdatedCount)
                .HasDefaultValue(0);
            builder.HasOne(x => x.AppUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(x => x.AppUserId);
        }
    }
}
