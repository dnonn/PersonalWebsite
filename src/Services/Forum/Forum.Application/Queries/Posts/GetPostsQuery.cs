using BuildingBlocks.Application.Models;
using Forum.Application.Models;
using MediatR;

namespace Forum.Application.Queries.Posts
{
    public class GetPostsQuery : IRequest<PaginatedList<PostCollectionModel>>
    {
        public string AreaHashId { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public GetPostsQuery(string areaHashId, int pageNumber, int pageSize)
        {
            AreaHashId = areaHashId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
