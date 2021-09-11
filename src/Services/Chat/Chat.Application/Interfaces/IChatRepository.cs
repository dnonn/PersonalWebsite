using Chat.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface IChatRepository
    {
        Task CreateMessageAsync(Message message, CancellationToken cancellationToken);

        Task DeleteMessageAsync(Message message, CancellationToken cancellationToken);

        Task<List<Message>> GetMessagesAsync(CancellationToken cancellationToken);
    }
}
