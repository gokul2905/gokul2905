namespace Ecommerce.Query.Services.Endpoints;

public static class MapEntityRoutes
{
    public static IEndpointRouteBuilder MapEntityEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapCategoryEndpoints();
        endpoints.MapProductEndpoints();
        endpoints.MapCustomerEndpoints();
        endpoints.MapOrderEndpoints();
        endpoints.MapOrderItemEndpoints();
        return endpoints;
    }
}
