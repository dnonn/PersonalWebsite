using BuildingBlocks.Application.Models;
using Forum.Application.Models;
using MediatR;

namespace Forum.Application.Queries.Posts
{
    public class GetCommentsQuery : IRequest<PaginatedList<CommentCollectionModel>>
    {
        public string PostHashId { get; }

        public string CommentHashId { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public GetCommentsQuery(string postHashId, string commentHashId, int pageNumber, int pageSize)
        {
            PostHashId = postHashId;
            PostHashId = commentHashId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
