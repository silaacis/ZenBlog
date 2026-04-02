using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.SubComment.Result;

namespace ZenBlog.Application.Features.SubComment.Queries;

public record GetSubCommentsQuery : IRequest<BaseResult<List<GetAllSubCommentQueryResult>>>;

