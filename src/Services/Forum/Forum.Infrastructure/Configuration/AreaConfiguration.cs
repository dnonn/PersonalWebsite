using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infrastructure.Configuration
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(a => a.AreaId);

            builder.HasMany(a => a.Posts)
                .WithOne(p => p.Area)
                .HasForeignKey(p => p.AreaId);

            builder.Ignore(a => a.DomainEvents);

            builder.Property(a => a.Route)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
