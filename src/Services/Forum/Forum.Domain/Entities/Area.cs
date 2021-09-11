using BuildingBlocks.Domain.Entities;
using System.Collections.Generic;

namespace Forum.Domain.Entities
{
    public class Area : AuditableEntity, IHasDomainEvent
    {
        public int AreaId { get; set; }

        public string Route { get; set; }

        public List<Post> Posts { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
