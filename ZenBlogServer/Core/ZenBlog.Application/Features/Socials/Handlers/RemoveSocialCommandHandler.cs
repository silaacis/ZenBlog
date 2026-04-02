using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class RemoveSocialCommandHandler(IRepository<Social> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSocialCommand request, CancellationToken cancellationToken)
        {
            var social = await repository.GetByIdAsync(request.Id);
            if (social == null)
            {
                return BaseResult<object>.NotFound("Social Not Found");
            }
            repository.Delete(social);
            await unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Social Deleted Successfully");
        }
    }
}
