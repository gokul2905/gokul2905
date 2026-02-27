using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.MinimalAPI;

namespace Ecommerce.Query.Services.Endpoints;

public static class OrderItemEndpoints
{
    public static IEndpointRouteBuilder MapOrderItemEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseQueryRoutes<OrderItem, OrderItemDto, Guid>($"/api/v1/orderitems");
        return endpoints;
    }
}
