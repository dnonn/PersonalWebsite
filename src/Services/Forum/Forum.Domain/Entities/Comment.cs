using BuildingBlocks.Domain.Entities;
using System.Collections.Generic;

namespace Forum.Domain.Entities
{
    public class Comment : AuditableEntity, IHasDomainEvent
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public int? ParentCommentId { get; set; }

        public Comment ParentComment { get; set; }

        public List<Comment> Comments { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}