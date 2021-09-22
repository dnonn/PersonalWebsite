using BuildingBlocks.API.Controllers;
using BuildingBlocks.API.Models;
using BuildingBlocks.Application.Models;
using Forum.API.Models;
using Forum.Application.Commands.Areas;
using Forum.Application.Commands.Comments;
using Forum.Application.Commands.Posts;
using Forum.Application.Models;
using Forum.Application.Queries.Areas;
using Forum.Application.Queries.Comments;
using Forum.Application.Queries.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ForumController : ApiControllerBase
    {
        [HttpPost("Areas")]
        public async Task<ActionResult<string>> CreateArea(CreateAreaModel area)
        {
            return await Mediator.Send(new CreateAreaCommand(area.Route));
        }

        [HttpPost("Areas/{areaHashId}/Posts")]
        public async Task<ActionResult<string>> CreatePost(string areaHashId, CreatePostModel post)
        {
            return await Mediator.Send(new CreatePostCommand(areaHashId, post.Title, post.Content));
        }

        [HttpPost("Areas/{areaHashId}/Posts/{postHashId}/Comments")]
        public async Task<ActionResult<string>> CreateComment(string areaHashId, string postHashId, CreateCommentModel comment)
        {
            return await Mediator.Send(new CreateCommentCommand(postHashId, string.Empty, comment.Content));
        }

        [HttpPost("Areas/{areaHashId}/Posts/{postHashId}/Comments/{commentHashId}")]
        public async Task<ActionResult<string>> CreateSubComment(string areaHashId, string postHashId, string commentHashId, CreateCommentModel comment)
        {
            return await Mediator.Send(new CreateCommentCommand(postHashId, commentHashId, comment.Content));
        }

        [HttpGet("Areas")]
        public async Task<ActionResult<PaginatedList<AreaCollectionModel>>> GetAreas(PaginatedListFilter filter)
        {
            return await Mediator.Send(new GetAreasQuery(filter.PageNumber, filter.PageSize));
        }

        [HttpGet("Areas/{areaHashId}/Posts")]
        public async Task<ActionResult<PaginatedList<PostCollectionModel>>> GetPosts(string areaHashId, PaginatedListFilter filter)
        {
            return await Mediator.Send(new GetPostsQuery(areaHashId, filter.PageNumber, filter.PageSize));
        }

        [HttpGet("Areas/{areaHashId}/Posts/{postHashId}")]
        public async Task<ActionResult<PostModel>> GetPost(string areaHashId, string postHashId)
        {
            return await Mediator.Send(new GetPostQuery(postHashId));
        }

        [HttpGet("Areas/{areaHashId}/Posts/{postHashId}/Comments")]
        public async Task<ActionResult<PaginatedList<CommentCollectionModel>>> GetComments(string areaHashId, string postHashId, PaginatedListFilter filter)
        {
            return await Mediator.Send(new GetCommentsQuery(postHashId, filter.PageNumber, filter.PageSize));
        }
        
        [HttpGet("Areas/{areaHashId}/Posts/{postHashId}/Comments/{commentHashId}")]
        public async Task<ActionResult<PaginatedList<CommentCollectionModel>>> GetSubComments(string areaHashId, string postHashId, string commentHashId, PaginatedListFilter filter)
        {
            return await Mediator.Send(new GetSubCommentsQuery(commentHashId, filter.PageNumber, filter.PageSize));
        }
    }
}
