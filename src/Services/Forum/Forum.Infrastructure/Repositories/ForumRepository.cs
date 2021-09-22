using BuildingBlocks.Application.Exceptions;
using BuildingBlocks.Application.Interfaces;
using BuildingBlocks.Application.Models;
using Forum.Application.Interfaces;
using Forum.Application.Models;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly ForumContext _context;
        private readonly IHashIdService _hashIdService;

        public ForumRepository(ForumContext context, IHashIdService hashIdService)
        {
            _context = context;
            _hashIdService = hashIdService;
        }

        public async Task CreateAreaAsync(Area area, CancellationToken cancellationToken)
        {
            await _context.AddAsync(area, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateCommentAsync(Comment comment, CancellationToken cancellationToken)
        {
            await _context.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CreatePostAsync(Post post, CancellationToken cancellationToken)
        {
            await _context.AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> RouteExistsAsync(string route, CancellationToken cancellationToken)
        {
            var routeParameter = new NpgsqlParameter("@Route", $"%{route}%");
            return await _context.Areas
                .FromSqlRaw($@"
                    SELECT ""Route""
                    FROM ""Areas""
                    WHERE ""Route"" LIKE @Route
                    LIMIT 1",
                    routeParameter)
                .AnyAsync(cancellationToken);
        }

        public async Task<PaginatedList<AreaCollectionModel>> GetAreasAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Areas
                .AsNoTracking()
                .OrderBy(a => a.Created)
                .Select(a => new AreaCollectionModel
                {
                    HashId = _hashIdService.Encode(a.AreaId),
                    Route = a.Route
                })
                .CreateAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<PaginatedList<CommentCollectionModel>> GetCommentsAsync(string postHashId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Comments
                .Where(c => c.Post.PostId == _hashIdService.Decode(postHashId) && !c.ParentCommentId.HasValue)
                .AsNoTracking()
                .Include(c => c.Comments)
                .OrderBy(c => c.Created)
                .Select(c => new CommentCollectionModel
                {
                    HashId = _hashIdService.Encode(c.CommentId),
                    Content = c.Content,
                    CreatedBy = c.CreatedBy
                })
                .CreateAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<PaginatedList<CommentCollectionModel>> GetSubCommentsAsync(string commentHashId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Comments
                .Where(c => c.ParentCommentId == _hashIdService.Decode(commentHashId))
                .AsNoTracking()
                .Include(c => c.Comments)
                .OrderBy(c => c.Created)
                .Select(c => new CommentCollectionModel
                {
                    HashId = _hashIdService.Encode(c.CommentId),
                    Content = c.Content,
                    CreatedBy = c.CreatedBy
                })
                .CreateAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<PaginatedList<PostCollectionModel>> GetPostsAsync(string areaHashId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Posts
                .Where(p => p.Area.AreaId == _hashIdService.Decode(areaHashId))
                .AsNoTracking()
                .Select(p => new PostCollectionModel
                {
                    HashId = _hashIdService.Encode(p.PostId),
                    Title = p.Title,
                    CreatedBy = p.CreatedBy
                })
                .CreateAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<PostModel> GetPostAsync(string postHashId, CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PostId == _hashIdService.Decode(postHashId), cancellationToken);

            if (post == null)
            {
                throw new NotFoundException("post", postHashId);
            }

            return new PostModel
            {
                Title = post.Title,
                Content = post.Content,
                HashId = _hashIdService.Encode(post.PostId)
            };
        }
    }
}
