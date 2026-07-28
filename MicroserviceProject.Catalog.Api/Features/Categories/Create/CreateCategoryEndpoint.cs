using MediatR;
using MicroserviceProject.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceProject.Catalog.Api.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateCategoryCommand Command, IMediator mediator) => (await mediator.Send(Command)).ToGenericResult());

            return group;
        }
    }
}
