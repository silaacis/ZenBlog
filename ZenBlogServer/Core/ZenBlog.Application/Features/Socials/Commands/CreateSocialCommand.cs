using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands
{
    public record CreateSocialCommand : IRequest<BaseResult<object>>
    {
        public string Title { get; init; }
        public string Url { get; init; }
        public string Icon { get; init; }
    }
}
