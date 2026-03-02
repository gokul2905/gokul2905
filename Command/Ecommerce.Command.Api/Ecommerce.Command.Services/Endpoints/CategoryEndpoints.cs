using CoreKit.MinimalApi;
using Ecommerce.Entities.Entities;
using Ecommerce.Command.Dto;

namespace Ecommerce.Command.Services.Endpoints;

public static class CategoryEndpoints
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseCommandRoutes<Category, CategoryDto, Guid>("/api/v1/categories");
        return endpoints;
    }
}
