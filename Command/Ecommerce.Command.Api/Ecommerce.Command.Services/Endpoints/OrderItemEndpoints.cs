using Ecommerce.Entities.Entities;
using Ecommerce.Command.Dto;
using Ecommerce.Command.Services.Services.MinimalAPI;

namespace Ecommerce.Command.Services.Endpoints;

public static class OrderItemEndpoints
{
    public static IEndpointRouteBuilder MapOrderItemEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseCommandRoutes<OrderItem, OrderItemDto, Guid>($"/api/v1/orderitems");
        return endpoints;
    }
}
