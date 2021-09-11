using BuildingBlocks.Application.Interfaces;
using BuildingBlocks.Infrastructure;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure
{
    public class ForumContext : ContextBase<ForumContext>
    {
        public DbSet<Area> Areas { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public ForumContext(
            DbContextOptions<ForumContext> options,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService,
            IDateTime dateTime)
            : base(options, currentUserService, domainEventService, dateTime)
        { }
    }
}
