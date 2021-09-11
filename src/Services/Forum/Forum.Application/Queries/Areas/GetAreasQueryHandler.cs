using BuildingBlocks.Application.Models;
using Forum.Application.Interfaces;
using Forum.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Areas
{
    public class GetAreasQueryHandler : IRequestHandler<GetAreasQuery, PaginatedList<AreaCollectionModel>>
    {
        private readonly IForumRepository _forumRepository;

        public GetAreasQueryHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        public async Task<PaginatedList<AreaCollectionModel>> Handle(GetAreasQuery request, CancellationToken cancellationToken)
        {
            return await _forumRepository.GetAreasAsync(request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
