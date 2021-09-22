using BuildingBlocks.Application.Interfaces;
using BuildingBlocks.Events;
using BuildingBlocks.Infrastructure;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure
{
    public class ChatContext : ContextBase<ChatContext>
    {
        public DbSet<Message> Messages { get; set; }

        public ChatContext(
            DbContextOptions<ChatContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options, currentUserService, dateTime)
        { }
    }
}
