using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands;

public record UpdateSocialCommand(Guid Id, string Title, string Icon, string Url) : IRequest<BaseResult<object>>;

