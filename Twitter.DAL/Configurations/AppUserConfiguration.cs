using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Core.Entities;

namespace Twitter.DAL.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(b => b.Fullname)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(b=>b.BirthDate)
            .IsRequired()
            .HasColumnType("date");
    }
}
