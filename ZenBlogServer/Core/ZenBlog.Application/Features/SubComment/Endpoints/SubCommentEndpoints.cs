using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.SubComment.Commands;
using ZenBlog.Application.Features.SubComment.Queries;

namespace ZenBlog.Application.Features.SubComment.Endpoints
{
    public static class SubCommentEndpoints
    {
        public static void RegisterSubCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var subComments = app.MapGroup("/subcomments").WithTags("SubComments");
            
            subComments.MapPost("", async (IMediator _mediator, CreateSubCommentCommand command) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            subComments.MapGet("", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSubCommentsQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComments.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSubCommentByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComments.MapPut("", async (IMediator _mediator, UpdateSubCommentCommand command) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComments.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveSubCommentCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });


        }
    }
}
