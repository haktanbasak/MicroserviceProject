using AutoMapper;
using MediatR;
using MicroserviceProject.Catalog.Api.Features.Categories.Dtos;
using MicroserviceProject.Catalog.Api.Features.Categories.GetAll;
using MicroserviceProject.Catalog.Api.Repositories;
using MicroserviceProject.Shared;
using MicroserviceProject.Shared.Extensions;
using System.Net;

namespace MicroserviceProject.Catalog.Api.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<ServiceResult<CategoryDto>>;

    public class GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.FindAsync(new object[] { request.Id }, cancellationToken: cancellationToken);

            if (hasCategory == null)
            {
                return ServiceResult<CategoryDto>.Error($"Category not found.", $"The category with Id({request.Id}) was not found", HttpStatusCode.NotFound);
            }

            var categoryAsDto = mapper.Map<CategoryDto>(hasCategory);

            return ServiceResult<CategoryDto>.SuccessAsOk(categoryAsDto);
        }
    }
    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}",
                async (IMediator mediator, Guid id) =>
                    (await mediator.Send(new GetCategoryByIdQuery(id))).ToGenericResult());

            return group;
        }
    }
}
