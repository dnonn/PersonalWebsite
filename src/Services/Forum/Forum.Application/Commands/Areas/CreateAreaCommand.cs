using MediatR;

namespace Forum.Application.Commands.Areas
{
    public class CreateAreaCommand : IRequest<string>
    {
        public string Route { get; }

        public CreateAreaCommand(string route)
        {
            Route = route;
        }
    }
}
