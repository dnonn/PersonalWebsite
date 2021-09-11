using Forum.Application.Models;
using MediatR;

namespace Forum.Application.Queries.Posts
{
    public class GetPostQuery : IRequest<PostModel>
    {
        public string PostHashId { get; }

        public GetPostQuery(string postHashId)
        {
            PostHashId = postHashId;
        }
    }
}
