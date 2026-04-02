using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class RemoveContactInfoCommandHandler(IRepository<ContactInfo> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                return BaseResult<object>.Fail("Contact info not found");
            }

            repository.Delete(value);
            await unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Contact info deleted");
        }
    }
}
