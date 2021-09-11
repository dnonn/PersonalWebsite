using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infrastructure.Configuration
{
    class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.PostId);

            builder.HasOne(p => p.Area)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.AreaId);

            builder.HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);

            builder.Ignore(p => p.DomainEvents);

            builder.Property(p => p.Content)
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(p => p.Title)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
