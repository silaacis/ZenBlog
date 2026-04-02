using FluentValidation;
using ZenBlog.Application.Features.Comments.Commands;

namespace ZenBlog.Application.Features.Comments.Validators
{
    public class CreateCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Name is required").EmailAddress();
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("blog is required");
            RuleFor(x => x.Body).NotEmpty().WithMessage("MessageBody is required");
        }
    }
}
