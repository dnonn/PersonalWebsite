using BuildingBlocks.Application.Interfaces;
using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Commands.Messages
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IChatRepository _chatRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateMessageCommandHandler(IChatRepository chatRepository, ICurrentUserService currentUserService)
        {
            _chatRepository = chatRepository;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = new Message
            {
                Content = request.Text
            };

            await _chatRepository.CreateMessageAsync(entity, cancellationToken);

            return entity.MessageId;
        }
    }
}
