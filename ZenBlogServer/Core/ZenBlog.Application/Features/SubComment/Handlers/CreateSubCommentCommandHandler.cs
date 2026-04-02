using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComment.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComment.Handlers
{
    public class CreateSubCommentCommandHandler(IRepository<ZenBlog.Domain.Entities.SubComment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = _mapper.Map<ZenBlog.Domain.Entities.SubComment>(request);
            await _repository.CreateAsync(subComment);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success(subComment);

        }
    }
}
