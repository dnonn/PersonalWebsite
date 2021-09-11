using Chat.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Chat.Application.Queries.Messages
{
    public class GetMessagesQuery : IRequest<List<MessageModel>>
    { }
}
