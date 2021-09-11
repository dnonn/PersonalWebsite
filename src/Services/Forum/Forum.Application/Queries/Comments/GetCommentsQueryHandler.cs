using BuildingBlocks.Application.Interfaces;
using BuildingBlocks.Application.Models;
using Forum.Application.Interfaces;
using Forum.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Posts
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, PaginatedList<CommentCollectionModel>>
    {
        private readonly IForumRepository _forumRepository;
        private readonly IHashIdService _hashIdService;

        public GetCommentsQueryHandler(IForumRepository forumRepository, IHashIdService hashIdService)
        {
            _forumRepository = forumRepository;
            _hashIdService = hashIdService;
        }

        public async Task<PaginatedList<CommentCollectionModel>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _forumRepository.GetCommentsAsync(
                _hashIdService.Decode(request.PostHashId),
                _hashIdService.Decode(request.CommentHashId),
                request.PageNumber,
                request.PageSize,
                cancellationToken);
        }
    }
}
