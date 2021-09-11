using FluentValidation;

namespace Forum.Application.Commands.Comments
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotNull().WithMessage("Content is required")
                .MinimumLength(1).WithMessage("Content must be at least 1 character long.")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters.");
        }
    }
}
