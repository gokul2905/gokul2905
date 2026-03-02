using CoreKit.MinimalApi;
using Ecommerce.Entities.Entities;
using Ecommerce.Query.Dto;

namespace Ecommerce.Query.Services.Endpoints;

public static class CustomerEndpoints
{
    public static IEndpointRouteBuilder MapCustomerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapBaseQueryRoutes<Customer, CustomerDto, Guid>("/api/v1/customers");
        return endpoints;
    }
}
