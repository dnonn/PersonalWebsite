using BuildingBlocks.Application.Models;
using Forum.Application.Models;
using MediatR;

namespace Forum.Application.Queries.Comments
{
    public class GetCommentsQuery : IRequest<PaginatedList<CommentCollectionModel>>
    {
        public string PostHashId { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public GetCommentsQuery(string postHashId, int pageNumber, int pageSize)
        {
            PostHashId = postHashId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
