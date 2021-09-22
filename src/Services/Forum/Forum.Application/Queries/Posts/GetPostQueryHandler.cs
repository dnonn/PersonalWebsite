using BuildingBlocks.Application.Interfaces;
using Forum.Application.Interfaces;
using Forum.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Posts
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostModel>
    {
        private readonly IForumRepository _forumRepository;

        public GetPostQueryHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        public async Task<PostModel> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return await _forumRepository.GetPostAsync(request.PostHashId, cancellationToken);
        }
    }
}
