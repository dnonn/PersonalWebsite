using FluentValidation;

namespace Forum.Application.Commands.Posts
{
    class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotNull().WithMessage("Title is required")
                .MinimumLength(1).WithMessage("Title must be at least 1 character long.")
                .MaximumLength(300).WithMessage("Title cannot exceed 300 characters.");
            
            RuleFor(c => c.Content)
                .NotNull().WithMessage("Content is required")
                .MinimumLength(1).WithMessage("Content must be at least 1 character long.")
                .MaximumLength(5000).WithMessage("Content cannot exceed 5000 characters.");
        }
    }
}
