using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Queries;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class GetSocialsByIdQueryHandler(IRepository<Social> repository, IMapper mapper) : IRequestHandler<GetSocialsByIdQuery, BaseResult<GetSocialsByIdQueryResult>>
    {
        public async Task<BaseResult<GetSocialsByIdQueryResult>> Handle(GetSocialsByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                return BaseResult<GetSocialsByIdQueryResult>.NotFound($"No Social found with Id {request.Id}");
            }
            var social = mapper.Map<GetSocialsByIdQueryResult>(value);
            return BaseResult<GetSocialsByIdQueryResult>.Success(social);
        }
    }
}
