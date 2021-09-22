using System.Threading.Tasks;

namespace BuildingBlocks.Events
{
    public interface IDomainEventService
    {
        Task PublishAsync<T>(T domainEvent);
    }
}
