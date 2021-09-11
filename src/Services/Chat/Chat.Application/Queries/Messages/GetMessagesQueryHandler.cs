using Chat.Application.Interfaces;
using Chat.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Queries.Messages
{
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, List<MessageModel>>
    {
        private readonly IChatRepository _chatRepository;

        public GetMessagesQueryHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<List<MessageModel>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _chatRepository.GetMessagesAsync(cancellationToken);

            var messageModels = messages.Select(m => new MessageModel
            {
                MessageId = m.MessageId,
                CreatedBy = m.CreatedBy,
                Text = m.Content
            }).ToList();

            return messageModels;
        }
    }
}
