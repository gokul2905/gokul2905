using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.MinimalAPI;

namespace Ecommerce.Query.Services.Endpoints;

public static class OrderEndpoints
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseQueryRoutes<Order, OrderDto, Guid>($"/api/v1/orders");
        return endpoints;
    }
}
