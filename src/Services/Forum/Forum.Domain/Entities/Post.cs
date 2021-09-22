using BuildingBlocks.Domain.Entities;
using System.Collections.Generic;

namespace Forum.Domain.Entities
{
    public class Post : AuditableEntity
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AreaId { get; set; }

        public Area Area { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
