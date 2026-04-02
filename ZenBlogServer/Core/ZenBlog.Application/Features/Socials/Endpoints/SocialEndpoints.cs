using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Queries;

namespace ZenBlog.Application.Features.Socials.Endpoints
{
    public static class SocialEndpoints
    {
        public static void RegisterSocialEndpoints(this IEndpointRouteBuilder app)
        {
            var socials = app.MapGroup("/socials").WithTags("Socials");

            socials.MapPost("", async (IMediator mediator, CreateSocialCommand command) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            socials.MapGet("", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetSocialsQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            socials.MapGet("{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetSocialsByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            socials.MapPut("", async (IMediator mediator, UpdateSocialCommand command) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            socials.MapDelete("{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new RemoveSocialCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
    

