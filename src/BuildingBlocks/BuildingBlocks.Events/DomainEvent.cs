using System;

namespace BuildingBlocks.Events
{
    public abstract class DomainEvent
    {
        public Guid Id { get; protected set; }
        
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            DateOccurred = DateTimeOffset.UtcNow;
        }
    }
}
