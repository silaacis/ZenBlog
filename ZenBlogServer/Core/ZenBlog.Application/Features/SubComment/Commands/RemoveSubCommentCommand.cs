using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComment.Commands
{
    public record RemoveSubCommentCommand(Guid Id) : IRequest<BaseResult<object>>
    {

    }
}
