using MassTransit;
using System.Threading.Tasks;

namespace BuildingBlocks.Events
{
    public class DomainEventService : IDomainEventService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public DomainEventService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishAsync<T>(T domainEvent)
        {
            await _publishEndpoint.Publish(domainEvent);
        }
    }
}
