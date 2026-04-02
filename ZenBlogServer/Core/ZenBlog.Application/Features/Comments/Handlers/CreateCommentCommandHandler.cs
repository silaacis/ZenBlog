using AutoMapper;
using MediatR;
using System.Net.WebSockets;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class CreateCommentCommandHandler(IRepository<Comment> _repository, IUnitOfWork unitOfWork, IMapper _mapper) : IRequestHandler<CreateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);
            await _repository.CreateAsync(comment);
            await unitOfWork.SaveChangeAsync();
            return BaseResult<object>.Success(comment);
        }
    }
}
