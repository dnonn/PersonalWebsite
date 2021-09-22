using BuildingBlocks.Application.Models;
using Forum.Application.Models;
using MediatR;

namespace Forum.Application.Queries.Comments
{
    public class GetSubCommentsQuery : IRequest<PaginatedList<CommentCollectionModel>>
    {
        public string CommentHashId { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public GetSubCommentsQuery(string commentHashId, int pageNumber, int pageSize)
        {
            CommentHashId = commentHashId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
