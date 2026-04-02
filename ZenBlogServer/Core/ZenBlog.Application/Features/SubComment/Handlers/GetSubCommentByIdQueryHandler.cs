using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComment.Queries;
using ZenBlog.Application.Features.SubComment.Result;

namespace ZenBlog.Application.Features.SubComment.Handlers
{
    public class GetSubCommentByIdQueryHandler(IRepository<ZenBlog.Domain.Entities.SubComment> _repository, IMapper _mapper) : IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetSubCommentByIdQueryResult>> Handle(GetSubCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if(value is null)
            {
                return BaseResult<GetSubCommentByIdQueryResult>.NotFound("SubComment Not Found");
            }

            var subComment = _mapper.Map<GetSubCommentByIdQueryResult>(value);
            return BaseResult<GetSubCommentByIdQueryResult>.Success(subComment);
        }
    }
}
