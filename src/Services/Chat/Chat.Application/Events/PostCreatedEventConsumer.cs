using BuildingBlocks.Events;
using Chat.Application.Commands.Messages;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Chat.Application.Events
{
    public class PostCreatedEventConsumer : IConsumer<PostCreatedEvent>
    {
        private readonly ILogger<PostCreatedEventConsumer> _logger;

        private readonly IMediator _mediator;

        public PostCreatedEventConsumer(ILogger<PostCreatedEventConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<PostCreatedEvent> context)
        {
            _logger.LogInformation("PostCreatedEvent consumed successfully. Created Post Id : {id}", context.Message.PostId);
            
            await _mediator.Send(new CreateMessageCommand($"A new post has been made: {context.Message.Title}"));
        }
    }
}
