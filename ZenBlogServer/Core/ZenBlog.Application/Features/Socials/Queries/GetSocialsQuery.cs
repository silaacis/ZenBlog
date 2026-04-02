using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Socials.Result;

namespace ZenBlog.Application.Features.Socials.Queries
{
    public class GetSocialsQuery : IRequest<BaseResult<List<GetSocialsQueryResult>>>
    {
    }
}
