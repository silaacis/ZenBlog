using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class CreateSocialCommandHandler(IRepository<Social> repository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
        {
            var social = mapper.Map<Social>(request);
            await repository.CreateAsync(social);
            await unitOfWork.SaveChangeAsync();

            return BaseResult<object>.Success(social);
        }
    }
}
