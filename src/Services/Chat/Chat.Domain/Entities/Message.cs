using BuildingBlocks.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chat.Domain.Entities
{
    public class Message : AuditableEntity, IHasDomainEvent
    {
        public int MessageId { get; set; }

        public string Content { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
