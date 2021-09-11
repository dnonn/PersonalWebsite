using MediatR;

namespace Chat.Application.Commands.Messages
{
    public class CreateMessageCommand : IRequest<int>
    {
        public string Text { get; }

        public CreateMessageCommand(string text)
        {
            Text = text;
        }
    }
}
