using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetMessagesByIdQueryHandler(IRepository<Message> repository, IMapper mapper) : IRequestHandler<GetMessagesByIdQuery, BaseResult<GetMessagesByIdQueryResult>>
    {
        public async Task<BaseResult<GetMessagesByIdQueryResult>> Handle(GetMessagesByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            if (value is null)
            {
                return BaseResult<GetMessagesByIdQueryResult>.NotFound($"Message with id {request.Id} not found");
            }

            var result = mapper.Map<GetMessagesByIdQueryResult>(value);
            return BaseResult<GetMessagesByIdQueryResult>.Success(result);
            
        }
    }
}
