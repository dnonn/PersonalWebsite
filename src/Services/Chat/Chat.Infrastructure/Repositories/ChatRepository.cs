using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatContext _context;

        public ChatRepository(ChatContext context)
        {
            _context = context;
        }

        public async Task CreateMessageAsync(Message message, CancellationToken cancellationToken)
        {
            await _context.AddAsync(message, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteMessageAsync(Message message, CancellationToken cancellationToken)
        {
            _context.Remove(message);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Message>> GetMessagesAsync(CancellationToken cancellationToken)
        {
            return await _context.Messages.ToListAsync(cancellationToken);
        }
    }
}
