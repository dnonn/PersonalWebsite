using FluentValidation;
using Forum.Application.Interfaces;

namespace Forum.Application.Commands.Areas
{
    public class CreateAreaCommandValidator : AbstractValidator<CreateAreaCommand>
    {
        private readonly IForumRepository _forumRepository;

        public CreateAreaCommandValidator(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;

            RuleFor(c => c.Route)
                .NotNull().WithMessage("Route is required")
                .MinimumLength(1).WithMessage("Route must be at least 1 character long.")
                .MaximumLength(100).WithMessage("Route cannot exceed 100 characters.")
                .MustAsync(async (route, cancellationToken) => !await _forumRepository.RouteExistsAsync(route, cancellationToken));
        }
    }
}
