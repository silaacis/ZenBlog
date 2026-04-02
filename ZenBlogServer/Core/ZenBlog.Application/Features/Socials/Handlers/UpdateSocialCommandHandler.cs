using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class UpdateSocialCommandHandler(IRepository<Social> repository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                return BaseResult<object>.NotFound($"Social with Id {request.Id} not found");
            }

            value = mapper.Map(request, value);
            repository.Update(value);
            await unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Social Updated Successfully");    
        }
    }
}
