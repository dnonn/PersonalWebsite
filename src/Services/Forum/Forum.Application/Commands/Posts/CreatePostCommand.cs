using MediatR;

namespace Forum.Application.Commands.Posts
{
    public class CreatePostCommand : IRequest<string>
    {
        public string AreaHashId { get; }

        public string Title { get; }

        public string Content { get; }


        public CreatePostCommand(string areaHashId, string title, string content)
        {
            AreaHashId = areaHashId;
            Title = title;
            Content = content;
        }
    }
}
