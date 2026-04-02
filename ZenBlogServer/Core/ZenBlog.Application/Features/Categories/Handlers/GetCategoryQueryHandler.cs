using AutoMapper;
using MediatR;
using System.Net.WebSockets;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Queries;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers;

internal class GetCategoryQueryHandler(IRepository<Category> _repository, IMapper mapper) : IRequestHandler<GetCategoryQuery, BaseResult<List<GetCategoryQueryResult>>>
{
    public async Task<BaseResult<List<GetCategoryQueryResult>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync();   
        var response = mapper.Map<List<GetCategoryQueryResult>>(categories);
        return BaseResult<List<GetCategoryQueryResult>>.Success(response);
    }
}
