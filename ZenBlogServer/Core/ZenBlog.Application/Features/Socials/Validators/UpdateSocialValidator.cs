using FluentValidation;
using ZenBlog.Application.Features.Socials.Commands;

namespace ZenBlog.Application.Features.Socials.Validators
{
    public class UpdateSocialValidator : AbstractValidator<UpdateSocialCommand>
    {
        public UpdateSocialValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url is required").Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Url must be a valid absolute URL");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon is required");

        }
    }
}
