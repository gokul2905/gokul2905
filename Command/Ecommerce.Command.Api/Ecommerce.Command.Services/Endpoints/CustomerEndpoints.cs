using Ecommerce.Entities.Entities;
using Ecommerce.Command.Dto;
using Ecommerce.Command.Services.Services.MinimalAPI;

namespace Ecommerce.Command.Services.Endpoints;

public static class CustomerEndpoints
{
    public static IEndpointRouteBuilder MapCustomerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseCommandRoutes<Customer, CustomerDto, Guid>($"/api/v1/customers");
        return endpoints;
    }
}
