using BuildingBlocks.Application.Interfaces;
using BuildingBlocks.Events;
using Forum.Application.Interfaces;
using Forum.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Commands.Posts
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, string>
    {
        private readonly IForumRepository _forumRepository;

        private readonly IHashIdService _hashIdService;

        private readonly IDomainEventService _domainEventService;

        public CreatePostCommandHandler(
            IForumRepository forumRepository,
            IHashIdService hashIdService,
            IDomainEventService domainEventService)
        {
            _forumRepository = forumRepository;
            _hashIdService = hashIdService;
            _domainEventService = domainEventService;
        }

        public async Task<string> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = new Post
            {
                AreaId = _hashIdService.Decode(request.AreaHashId),
                Title = request.Title,
                Content = request.Content
            };
            

            await _forumRepository.CreatePostAsync(entity, cancellationToken);
            await _domainEventService.PublishAsync(new PostCreatedEvent(entity.PostId, entity.Title, entity.Content, entity.AreaId));

            return _hashIdService.Encode(entity.PostId);
        }
    }
}
