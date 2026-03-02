using CoreKit.MinimalApi;
using Ecommerce.Entities.Entities;
using Ecommerce.Command.Dto;

namespace Ecommerce.Command.Services.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseCommandRoutes<Product, ProductDto, Guid>("/api/v1/products");
        return endpoints;
    }
}
