using FluentValidation;
using ZenBlog.Application.Features.Socials.Commands;

namespace ZenBlog.Application.Features.Socials.Validators
{
    public class CreateSocialValidator : AbstractValidator<CreateSocialCommand>
    {
        public CreateSocialValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Url is required")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Url must be a valid absolute URL");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon is required")
                .MaximumLength(50).WithMessage("Icon must not exceed 50 characters");
        }
    }
}
