using CoreKit.MinimalApi;
using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;

namespace Ecommerce.Query.Services.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseQueryRoutes<Product, ProductDto, Guid>("/api/v1/products");
        return endpoints;
    }
}
