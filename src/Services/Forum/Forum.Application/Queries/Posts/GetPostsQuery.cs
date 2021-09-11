using BuildingBlocks.Application.Models;
using Forum.Application.Models;
using MediatR;

namespace Forum.Application.Queries.Posts
{
    public class GetPostsQuery : IRequest<PaginatedList<PostCollectionModel>>
    {
        public string AreaRoute { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public GetPostsQuery(string areaRoute, int pageNumber, int pageSize)
        {
            AreaRoute = areaRoute;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
