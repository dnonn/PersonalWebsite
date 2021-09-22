using BuildingBlocks.Domain.Entities;

namespace Chat.Domain.Entities
{
    public class Message : AuditableEntity
    {
        public int MessageId { get; set; }

        public string Content { get; set; }
    }
}
