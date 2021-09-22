using BuildingBlocks.Application.Interfaces;
using Forum.Application.Interfaces;
using Forum.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Commands.Comments
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, string>
    {
        private readonly IForumRepository _forumRepository;

        private readonly IHashIdService _hashIdService;

        public CreateCommentCommandHandler(IForumRepository forumRepository, IHashIdService hashIdService)
        {
            _forumRepository = forumRepository;
            _hashIdService = hashIdService;
        }

        public async Task<string> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Comment
            {
                PostId = _hashIdService.Decode(request.PostHashId),
                Content = request.Content
            };

            if (!string.IsNullOrWhiteSpace(request.CommentHashId))
            {
                entity.ParentCommentId = _hashIdService.Decode(request.CommentHashId);
            }

            await _forumRepository.CreateCommentAsync(entity, cancellationToken);

            return _hashIdService.Encode(entity.CommentId);
        }
    }
}
