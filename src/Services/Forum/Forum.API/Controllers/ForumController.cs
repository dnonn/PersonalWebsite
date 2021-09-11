using BuildingBlocks.API.Controllers;
using BuildingBlocks.API.Models;
using BuildingBlocks.Application.Models;
using Forum.Application.Commands.Areas;
using Forum.Application.Commands.Comments;
using Forum.Application.Commands.Posts;
using Forum.Application.Models;
using Forum.Application.Queries.Areas;
using Forum.Application.Queries.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ForumController : ApiControllerBase
    {
        [HttpPost("Area")]
        public async Task<ActionResult<string>> CreateArea(AreaModel area)
        {
            return await Mediator.Send(new CreateAreaCommand(area.Route));
        }

        [HttpPost("Post")]
        public async Task<ActionResult<string>> CreatePost(PostModel post)
        {
            return await Mediator.Send(new CreatePostCommand(post.Title, post.Content));
        }

        [HttpPost("Comment")]
        public async Task<ActionResult<string>> CreateComment(CommentModel comment)
        {
            return await Mediator.Send(new CreateCommentCommand(comment.Content));
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<AreaCollectionModel>>> GetAreas(PaginatedListFilter filter)
        {
            return await Mediator.Send(new GetAreasQuery(filter.PageNumber, filter.PageSize));
        }

        [HttpGet("{areaRoute}")]
        public async Task<ActionResult<PaginatedList<PostCollectionModel>>> GetPosts(string areaRoute, PaginatedListFilter filter)
        {
            return await Mediator.Send(new GetPostsQuery(areaRoute, filter.PageNumber, filter.PageSize));
        }

        [HttpGet("posts/{postHashId}")]
        public async Task<ActionResult<PostModel>> GetPost(string postHashId)
        {
            return await Mediator.Send(new GetPostQuery(postHashId));
        }

        [HttpGet("posts/{postHashId}")]
        public async Task<ActionResult<PaginatedList<CommentCollectionModel>>> GetComments(string postHashId, PaginatedListFilter filter)
        {
            return await Mediator.Send(new GetCommentsQuery(postHashId, string.Empty, filter.PageNumber, filter.PageSize));
        }
        
        [HttpGet("posts/{postHashId}/comments/{commentHashId}")]
        public async Task<ActionResult<PaginatedList<CommentCollectionModel>>> GetSubComments(string commentHashId, PaginatedListFilter filter)
        {
            return await Mediator.Send(new GetCommentsQuery(string.Empty, commentHashId, filter.PageNumber, filter.PageSize));
        }
    }
}
