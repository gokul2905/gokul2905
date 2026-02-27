using Ecommerce.Query.Core;

namespace Ecommerce.Query.Services.Services.MinimalAPI;

public static class BaseQueryRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapBaseQueryRoutes<TEntity, TDto, TKey>(this IEndpointRouteBuilder endpoints, string pattern)
        where TEntity : class
        where TDto : class
    {
        var group = endpoints.MapGroup(pattern);
        group.MapGet("/", async (IBaseQueryService<TDto, TKey> service, CancellationToken cancellationToken) =>
            Results.Ok(await service.GetAllAsync(cancellationToken)));

        group.MapGet("/{id:guid}", async (TKey id, IBaseQueryService<TDto, TKey> service, CancellationToken cancellationToken) =>
        {
            var model = await service.GetByIdAsync(id, cancellationToken);
            return model is null ? Results.NotFound() : Results.Ok(model);
        });

        return endpoints;
    }
}
