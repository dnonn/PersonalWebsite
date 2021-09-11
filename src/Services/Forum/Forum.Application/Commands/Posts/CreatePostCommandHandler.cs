using BuildingBlocks.Application.Interfaces;
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

        private readonly ICurrentUserService _currentUserService;

        private readonly IHashIdService _hashIdService;

        public CreatePostCommandHandler(IForumRepository forumRepository, ICurrentUserService currentUserService, IHashIdService hashIdService)
        {
            _forumRepository = forumRepository;
            _currentUserService = currentUserService;
            _hashIdService = hashIdService;
        }

        public async Task<string> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = new Post
            {
                Username = _currentUserService.Username,
                Title = request.Title,
                Content = request.Content
            };

            await _forumRepository.CreatePostAsync(entity, cancellationToken);

            return _hashIdService.Encode(entity.PostId);
        }
    }
}
