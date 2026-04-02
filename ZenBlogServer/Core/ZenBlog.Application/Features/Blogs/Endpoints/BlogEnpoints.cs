using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Categories.Commands;

namespace ZenBlog.Application.Features.Blogs.Endpoints
{
    public static class BlogEnpoints
    {
        public static void RegisterBlogEndpoints(this IEndpointRouteBuilder app)
        {
            var blogs = app.MapGroup("/blogs").WithTags("Blogs");

            blogs.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogsQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            blogs.MapGet("Latest5Blogs", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetLatest5BlogsQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            blogs.MapPost(string.Empty, async (CreateBlogCommand command,IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapPut(string.Empty, async (UpdateBlogCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapGet("{id}",
                async (Guid id, IMediator _mediator) =>
                {
                    var response = await _mediator.Send(new GetBlogByIdQuery(id));
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            blogs.MapDelete("{id}",
                async (Guid id, IMediator _mediator) =>
                {
                    var response = await _mediator.Send(new RemoveBlogCommand(id));
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapGet("byCategoryId/{categoryId}",
                async (Guid categoryId, IMediator _mediator) =>
                {
                    var response = await _mediator.Send(new GetBlogsByCategoryIdQuery(categoryId));
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);

            });
        }
    }
}
