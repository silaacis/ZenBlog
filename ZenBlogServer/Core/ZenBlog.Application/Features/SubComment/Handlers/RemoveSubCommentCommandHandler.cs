using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComment.Commands;

namespace ZenBlog.Application.Features.SubComment.Handlers
{
    public class RemoveSubCommentCommandHandler(IRepository<ZenBlog.Domain.Entities.SubComment> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSubCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if(value is null)
            {
                return BaseResult<object>.Fail("SubComment Not Found");
            }

            _repository.Delete(value);
            await _unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success("SubComment Deleted Successfully");
        }
    }
}
