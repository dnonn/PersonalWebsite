using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infrastructure.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.CommentId);

            builder.HasOne(c => c.ParentComment)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ParentCommentId);

            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            builder.Ignore(c => c.DomainEvents);

            builder.Property(c => c.Content)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
