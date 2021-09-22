using BuildingBlocks.Application.Models;
using Forum.Application.Interfaces;
using Forum.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Comments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, PaginatedList<CommentCollectionModel>>
    {
        private readonly IForumRepository _forumRepository;

        public GetCommentsQueryHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        public async Task<PaginatedList<CommentCollectionModel>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _forumRepository.GetCommentsAsync(
                request.PostHashId,
                request.PageNumber,
                request.PageSize,
                cancellationToken);
        }
    }
}
