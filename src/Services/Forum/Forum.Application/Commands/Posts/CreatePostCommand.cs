using MediatR;

namespace Forum.Application.Commands.Posts
{
    public class CreatePostCommand : IRequest<string>
    {
        public string Title { get; }

        public string Content { get; }

        public CreatePostCommand(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
