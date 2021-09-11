using BuildingBlocks.API.Controllers;
using Chat.Application.Commands.Messages;
using Chat.Application.Models;
using Chat.Application.Queries.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ChatController : ApiControllerBase
    {
        [HttpGet("claims")]
        [Authorize]
        public IActionResult GetClaims()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpGet]
        public async Task<ActionResult<List<MessageModel>>> GetMessages()
        {
            return await Mediator.Send(new GetMessagesQuery());
        }

        [HttpPost]
        [Authorize(Policy = "CreateMessage")]
        public async Task<ActionResult<int>> CreateMessage(MessageModel model)
        {
            return await Mediator.Send(new CreateMessageCommand(model.Text));
        }
    }
}
