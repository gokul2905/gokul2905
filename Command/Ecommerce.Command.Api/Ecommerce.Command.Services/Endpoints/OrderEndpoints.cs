using CoreKit.MinimalApi;
using Ecommerce.Entities.Entities;
using Ecommerce.Command.Dto;

namespace Ecommerce.Command.Services.Endpoints;

public static class OrderEndpoints
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseCommandRoutes<Order, OrderDto, Guid>("/api/v1/orders");
        return endpoints;
    }
}
