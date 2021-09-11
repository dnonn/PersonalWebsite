using BuildingBlocks.Application.Models;
using Forum.Application.Models;
using MediatR;

namespace Forum.Application.Queries.Areas
{
    public class GetAreasQuery : IRequest<PaginatedList<AreaCollectionModel>>
    {
        public int PageNumber { get; }

        public int PageSize { get; }

        public GetAreasQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
