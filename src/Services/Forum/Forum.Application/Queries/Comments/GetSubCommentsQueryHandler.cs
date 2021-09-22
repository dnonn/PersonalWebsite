using BuildingBlocks.Application.Models;
using Forum.Application.Interfaces;
using Forum.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Comments
{
    public class GetSubCommentsQueryHandler : IRequestHandler<GetSubCommentsQuery, PaginatedList<CommentCollectionModel>>
    {
        private readonly IForumRepository _forumRepository;

        public GetSubCommentsQueryHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        public async Task<PaginatedList<CommentCollectionModel>> Handle(GetSubCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _forumRepository.GetSubCommentsAsync(
                request.CommentHashId,
                request.PageNumber,
                request.PageSize,
                cancellationToken);
        }
    }
}
