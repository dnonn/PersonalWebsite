using BuildingBlocks.Application.Models;
using Forum.Application.Interfaces;
using Forum.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Posts
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, PaginatedList<PostCollectionModel>>
    {
        private readonly IForumRepository _forumRepository;

        public GetPostsQueryHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        public async Task<PaginatedList<PostCollectionModel>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return await _forumRepository.GetPostsAsync(request.AreaRoute, request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
