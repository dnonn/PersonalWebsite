using BuildingBlocks.Application.Exceptions;
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

        public ForumRepository(ForumContext context)
        {
            _context = context;
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

        public async Task<PaginatedList<AreaCollectionModel>> GetAreasAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Areas
                .AsNoTracking()
                .OrderBy(a => a.Created)
                .Select(a => new AreaCollectionModel
                {
                    Route = a.Route,
                })
                .CreateAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<bool> RouteAvailableAsync(string route, CancellationToken cancellationToken)
        {
            var routeParameter = new NpgsqlParameter("@Route", $"%{route}%");
            return await _context.Areas
                .FromSqlRaw(@"
                    SELECT Route
                    FROM Areas
                    WHERE Route LIKE @Route
                    LIMIT 1",
                    routeParameter)
                .AnyAsync(cancellationToken);
        }

        public async Task<PaginatedList<CommentCollectionModel>> GetCommentsAsync(int? postId, int? commentId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var comments = _context.Comments.AsQueryable();
            if (postId.HasValue)
            {
                comments = comments.Where(c => c.Post.PostId == postId.Value);
            }

            if (commentId.HasValue)
            {
                comments = comments.Where(c => c.CommentId == commentId.Value);
            }

            return await comments
                .AsNoTracking()
                .Include(c => c.Comments)
                .OrderBy(c => c.Created)
                .Select(c => new CommentCollectionModel
                {
                    Content = c.Content,
                })
                .CreateAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<PaginatedList<PostCollectionModel>> GetPostsAsync(string areaRoute, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var routeParameter = new NpgsqlParameter("@Route", $"%{areaRoute}%");
            return await _context.Posts
                .FromSqlRaw(@"
                    SELECT *
                    FROM Posts
                    INNER JOIN Areas a USING(AreaId)
                    WHERE a.Route LIKE @Route",
                    routeParameter)
                .AsNoTracking()
                .Select(p => new PostCollectionModel
                {
                    Title = p.Title,
                })
                .CreateAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<PostModel> GetPostAsync(int postId, CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PostId == postId, cancellationToken);

            if (post == null)
            {
                throw new NotFoundException("post", postId);
            }

            return new PostModel
            {
                Title = post.Title,
                Content = post.Content
            };
        }
    }
}
