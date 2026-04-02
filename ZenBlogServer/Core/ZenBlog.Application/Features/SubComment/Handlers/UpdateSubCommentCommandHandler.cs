using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComment.Commands;

namespace ZenBlog.Application.Features.SubComment.Handlers
{
    public class UpdateSubCommentCommandHandler(IRepository<ZenBlog.Domain.Entities.SubComment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = await _repository.GetByIdAsync(request.Id);
            if (subComment == null) 
            {
                return BaseResult<object>.Fail("SubComment not found");
            }

            subComment = _mapper.Map(request, subComment);

            _repository.Update(subComment);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("SubComment Updated");

        }
    }
}
