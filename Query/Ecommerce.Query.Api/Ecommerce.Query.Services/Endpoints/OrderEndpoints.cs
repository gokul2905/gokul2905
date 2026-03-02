using CoreKit.MinimalApi;
using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;

namespace Ecommerce.Query.Services.Endpoints;

public static class OrderEndpoints
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseQueryRoutes<Order, OrderDto, Guid>("/api/v1/orders");
        return endpoints;
    }
}
