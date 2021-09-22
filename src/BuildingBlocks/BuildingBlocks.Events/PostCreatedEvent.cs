namespace BuildingBlocks.Events
{
    public class PostCreatedEvent : DomainEvent
    {
        public int PostId { get; }

        public string Title { get; }

        public string Content { get; }

        public int AreaId { get; }

        public PostCreatedEvent(int postId, string title, string content, int areaId)
            : base()
        {
            PostId = postId;
            Title = title;
            Content = content;
            AreaId = areaId;
        }
    }
}
