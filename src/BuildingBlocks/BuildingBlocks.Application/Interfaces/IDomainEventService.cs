using BuildingBlocks.Domain.Entities;
using System.Threading.Tasks;

namespace BuildingBlocks.Application.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
