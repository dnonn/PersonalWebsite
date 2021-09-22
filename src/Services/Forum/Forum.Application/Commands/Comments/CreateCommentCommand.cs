using MediatR;

namespace Forum.Application.Commands.Comments
{
    public class CreateCommentCommand : IRequest<string>
    {
        public string PostHashId { get; }

        public string CommentHashId { get; }

        public string Content { get; }

        public CreateCommentCommand(string postHashId, string commentHashId, string content)
        {
            PostHashId = postHashId;
            CommentHashId = commentHashId;
            Content = content;
        }
    }
}
