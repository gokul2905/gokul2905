using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;
using Ecommerce.Query.Services.Services.MinimalAPI;

namespace Ecommerce.Query.Services.Endpoints;

public static class CustomerEndpoints
{
    public static IEndpointRouteBuilder MapCustomerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseQueryRoutes<Customer, CustomerDto, Guid>($"/api/v1/customers");
        return endpoints;
    }
}
