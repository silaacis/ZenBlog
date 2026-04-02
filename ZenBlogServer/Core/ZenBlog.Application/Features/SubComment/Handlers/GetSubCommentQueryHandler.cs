using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComment.Queries;
using ZenBlog.Application.Features.SubComment.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComment.Handlers
{
    public class GetSubCommentQueryHandler(IRepository<ZenBlog.Domain.Entities.SubComment> _repository, IMapper _mapper) : IRequestHandler<GetSubCommentsQuery, BaseResult<List<GetAllSubCommentQueryResult>>>
    {
        public async Task<BaseResult<List<GetAllSubCommentQueryResult>>> Handle(GetSubCommentsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var subComments = _mapper.Map<List<GetAllSubCommentQueryResult>>(values);
            return BaseResult<List<GetAllSubCommentQueryResult>>.Success(subComments);
        }
    }
}
