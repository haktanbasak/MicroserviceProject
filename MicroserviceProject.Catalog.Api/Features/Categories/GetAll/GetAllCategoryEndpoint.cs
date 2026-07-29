using MediatR;
using MicroserviceProject.Catalog.Api.Features.Categories.Dtos;
using MicroserviceProject.Catalog.Api.Repositories;
using MicroserviceProject.Shared;
using MicroserviceProject.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceProject.Catalog.Api.Features.Categories.GetAll
{
    public class GetAllCategoryQuery: IRequest<ServiceResult<List<CategoryDto>>>;

    public class GetAllCategoryQueryHandler(AppDbContext context) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync();
            var categoriesAsDto = categories.Select(c => new CategoryDto(c.Id, c.Name)).ToList();
            return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoriesAsDto);
        }
    }

    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/",
                async (IMediator mediator) =>
                    (await mediator.Send(new GetAllCategoryQuery())).ToGenericResult());

            return group;
        }
    }
}
