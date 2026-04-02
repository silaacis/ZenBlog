using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers;

internal class RemoveCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id);
        if (category is null)
        {
            return BaseResult<bool>.Fail("Category not found.");
        }
        repository.Delete(category);
        var response = await unitOfWork.SaveChangeAsync();
        return response ? BaseResult<bool>.Success(true) : BaseResult<bool>.Fail("Failed to remove category.");
    }
}
