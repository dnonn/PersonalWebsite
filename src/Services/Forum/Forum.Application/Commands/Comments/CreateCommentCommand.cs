using MediatR;

namespace Forum.Application.Commands.Comments
{
    public class CreateCommentCommand : IRequest<string>
    {
        public string Content { get; }

        public CreateCommentCommand(string content)
        {
            Content = content;
        }
    }
}
