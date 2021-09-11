using BuildingBlocks.Application.Models;
using Forum.Application.Models;
using Forum.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Interfaces
{
    public interface IForumRepository
    {
        Task CreateCommentAsync(Comment comment, CancellationToken cancellationToken);

        Task CreatePostAsync(Post post, CancellationToken cancellationToken);

        Task CreateAreaAsync(Area area, CancellationToken cancellationToken);

        Task<bool> RouteAvailableAsync(string route, CancellationToken cancellationToken);

        Task<PaginatedList<AreaCollectionModel>> GetAreasAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task<PaginatedList<CommentCollectionModel>> GetCommentsAsync(int? postHashId, int? commentHashId, int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task<PaginatedList<PostCollectionModel>> GetPostsAsync(string route, int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task<PostModel> GetPostAsync(int postId, CancellationToken cancellationToken);
    }
}
