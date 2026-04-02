using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.ContactInfos.Queries;

namespace ZenBlog.Application.Features.ContactInfos.Endpoints
{
    public static class ContactInfoEndpoints
    {
        public static void RegisterContactInfoEndpoints(this IEndpointRouteBuilder app)
        {
            var contactInfos = app.MapGroup("contactinfos").WithTags("ContactInfos");

            contactInfos.MapGet("", async (IMediator _mediator) =>
            {
                var result = await _mediator.Send(new GetContactInfosQuery());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();

            contactInfos.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var result = await _mediator.Send(new GetContactInfoByIdQuery(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            contactInfos.MapPost("", async (IMediator _mediator, CreateContactInfoCommand command) =>
            {
                var result = await _mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            contactInfos.MapPut("", async (IMediator mediator, UpdateContactInfoCommand command) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            contactInfos.MapDelete("{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new RemoveContactInfoCommand(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });
        }
    }
}
