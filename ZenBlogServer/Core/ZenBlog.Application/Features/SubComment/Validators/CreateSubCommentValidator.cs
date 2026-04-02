using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.SubComment.Commands;

namespace ZenBlog.Application.Features.SubComment.Validators
{
    public class CreateSubCommentValidator : AbstractValidator<CreateSubCommentCommand>
    {
        public CreateSubCommentValidator()
        {   
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Name is required").EmailAddress();
            RuleFor(x => x.Body).NotEmpty().WithMessage("Comment is required").MaximumLength(200).WithMessage("Comment must not exceed 200 characters");
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("Comment is required");
                
        }
    }
}
