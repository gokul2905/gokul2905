using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.MinimalAPI;

namespace Ecommerce.Query.Services.Endpoints;

public static class CategoryEndpoints
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseQueryRoutes<Category, CategoryDto, Guid>($"/api/v1/categories");
        return endpoints;
    }
}
