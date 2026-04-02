using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class CreateContactInfoCommandHandler(IRepository<ContactInfo> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo = _mapper.Map<ContactInfo>(request);
            await _repository.CreateAsync(contactInfo);
            await _unitOfWork.SaveChangeAsync();

            return BaseResult<object>.Success(contactInfo);
        }
    }
}
