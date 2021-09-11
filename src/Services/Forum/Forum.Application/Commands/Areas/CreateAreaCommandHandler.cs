using Forum.Application.Interfaces;
using Forum.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Commands.Areas
{
    public class CreateAreaCommandHandler : IRequestHandler<CreateAreaCommand, string>
    {
        private readonly IForumRepository _forumRepository;
        
        public CreateAreaCommandHandler(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        public async Task<string> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
        {
            var entity = new Area
            {
                Route = request.Route
            };

            await _forumRepository.CreateAreaAsync(entity, cancellationToken);

            return entity.Route;
        }
    }
}
