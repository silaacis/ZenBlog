using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class UpdateMessageCommandHandler(IRepository<Message> repository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await repository.GetByIdAsync(request.Id);
            if (message == null)
            {
                return BaseResult<object>.NotFound("Message Not Found");
            }
            mapper.Map(request, message);
            repository.Update(message);
            await unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("Message Updated");
        }
    }
}
